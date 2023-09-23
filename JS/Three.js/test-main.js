import * as THREE from './build/three.module.js';
import {GLTFLoader} from './examples/jsm/loaders/GLTFLoader.js'
import Stats from './examples/jsm/libs/stats.module.js';
import { GUI } from './examples/jsm/libs/dat.gui.module.js';
import { OrbitControls } from './examples/jsm/controls/OrbitControls.js';
import {PLYLoader} from "./examples/jsm/loaders/PLYLoader.js";
import {JSONLoader} from "./build/three.module.js";

let cube;
let renderer, camera, scene, textMesh;
const gui = new GUI();
let envcamera;
let groundMesh;

let textData = {
    text: "Japanese characters are not supported!",
    size: 0.5,
    height: 0.2,
    curveSegments: 12,
    font: 'helvetiker',
    weight: 'regular',
    bevelEnabled: false,
    bevelThickness: 1,
    bevelSize: 0.5,
}
const fonts = [
    'helvetiker',
    'optimer',
    'gentilis',
    'droid/droid_sans'
];

const weights = [
    'regular',
    'bold'
];
function addGUIControls() {

    let textFolder = gui.addFolder('Settings');
    //
    textFolder.add(textData, 'text').onChange(generateTextGeometry);
    textFolder.add(textData, 'size', 0.1, 1).onChange(generateTextGeometry);
    textFolder.add(textData, 'height', 0.1, 1).onChange(generateTextGeometry);
    textFolder.add(textData, 'curveSegments', 1, 20).onChange(generateTextGeometry);
    textFolder.add(textData, 'font', fonts).onChange(generateTextGeometry);
    textFolder.add(textData, 'weight', weights).onChange(generateTextGeometry);
    textFolder.add(textData, 'bevelEnabled').onChange(generateTextGeometry);
    textFolder.add(textData, 'bevelThickness', 0.1, 3).onChange(generateTextGeometry);
    textFolder.add(textData, 'bevelSize', 0.1, 3).onChange(generateTextGeometry);
}

function generateTextGeometry() {
    let loader = new THREE.FontLoader();
    loader.load('./fonts/' + textData.font + '_' + textData.weight + '.typeface.json', (font) => {//
        let geometry = new THREE.TextGeometry(textData.text, {
            font: font,
            size: textData.size,
            height: textData.height,
            curveSegments: textData.curveSegments,
            bevelEnabled: textData.bevelEnabled,
            bevelThickness: textData.bevelThickness,
            bevelSize: textData.bevelSize
        });
        geometry.center();

        if (!textMesh) {
            let textMaterial = new THREE.MeshPhongMaterial({color: 0xcfcfcf, wireframe: false, transparent: false});//
            textMesh = new THREE.Mesh(geometry, textMaterial);
            textMesh.position.set(-4,0,-3);
            textMesh.rotation.set(0,-55.6,0);
            scene.add(textMesh);
        } else {
            textMesh.geometry.dispose();
            textMesh.geometry = geometry;
        }
        textMesh.castShadow=true;

    })
}

function main() {
    const canvas = document.querySelector('#c');
    renderer = new THREE.WebGLRenderer({canvas});

    renderer.shadowMap.enabled = true;
    renderer.shadowMap.type = THREE.PCFSoftShadowMap;

    const fov = 85;
    const aspect = 2;  // the canvas default
    const near = 0.1;
    const far = 1000;
    camera = new THREE.PerspectiveCamera(fov, aspect, near, far);
    camera.position.z = 2;

    const controls = new OrbitControls(camera, canvas);
    controls.enableDamping = true;
    controls.maxDistance = 20;
    controls.minDistance = 1;
    controls.target.set(0, 0, 0);
    controls.update();

    scene = new THREE.Scene();

    let textureLoader = new THREE.TextureLoader();

    let material = new THREE.MeshBasicMaterial({
        side: THREE.BackSide,
        map: textureLoader.load('assets/hdri-skies.jpg')
    });

    let skybox = new THREE.Mesh(new THREE.SphereGeometry(500,128,128), material);
    scene.add(skybox);


    const cubeRenderTarget = new THREE.WebGLCubeRenderTarget(512, {
        format: THREE.RGBFormat,
        generateMipmaps: true,
        minFilter: THREE.LinearMipmapLinearFilter
    });

    envcamera = new THREE.CubeCamera(1, 2000, cubeRenderTarget);
    envcamera.position.set(0,-5,0);
    scene.add(envcamera);


    let ambientLight = new THREE.AmbientLight(0x202020, 1);
    scene.add(ambientLight);


    // generateTextGeometry();
    let gGeometry= new THREE.PlaneGeometry(50,50);
    let gMaterial = new THREE.MeshPhongMaterial({
        // color: 0xaa11ee,
        wireframe: false,
        transparent: false,
        envMap: cubeRenderTarget.texture,
    });
    groundMesh = new THREE.Mesh(gGeometry, gMaterial);
    groundMesh.rotation.x = -Math.PI/2;
    groundMesh.position.y = -4;
    groundMesh.receiveShadow = true;
    groundMesh.castShadow = true;
    scene.add(groundMesh);

    const color = 0xFFFFFF;
    const intensity = 0.6;
    const light = new THREE.DirectionalLight(color, intensity);
    light.position.set(-1, 2, 4);
    light.castShadow = true;
    scene.add(light);

    const light2 = new THREE.AmbientLight(color, 1);
    light2.position.set(-5, 2, 6);
    // light2.castShadow = true;
    scene.add(light2);
    //
    const light3 = new THREE.DirectionalLight(color, intensity);
    light3.position.set(6, 2, -4);
    light3.castShadow = true;
    scene.add(light3);



    const boxWidth = 1;
    const boxHeight = 1;
    const boxDepth = 1;
    const geometry = new THREE.BoxGeometry(boxWidth, boxHeight, boxDepth);
    class ColorGUIHelper {
        constructor(object, prop) {
            this.object = object;
            this.prop = prop;
        }
        get value() {
            return `#${this.object[this.prop].getHexString()}`;
        }
        set value(hexString) {
            this.object[this.prop].set(hexString);
        }
    }
    let meshMaterial = new THREE.MeshStandardMaterial({ color: 0x0055ff, flatShading: true,});
    let dolphinFolder = gui.addFolder("dolphin");
    dolphinFolder.addColor(new ColorGUIHelper(meshMaterial, 'color'), 'value')
        .name('color')
        .onChange(requestRenderIfNotRequested);

    let guiControls = new function() {
        this.color = meshMaterial.color.getStyle();
        this.wireframe = meshMaterial.wireframe;
    };
    let loader = new PLYLoader();
    loader.load('./examples/models/ply/binary/dolphins_be.ply', function(statue) {
        //geometry.computeVertexNormals();
        var mesh = new THREE.Mesh(statue, meshMaterial);
        mesh.scale.multiplyScalar( 0.004 );
        mesh.position.x = 2;
        mesh.rotation.x= 29.9;
        mesh.rotation.z= 15;
        mesh.castShadow = true;
        dolphinFolder.add(guiControls, "wireframe")
            .onChange(function (e) {
                mesh.material.wireframe = e;
            });
        scene.add(mesh);
    });

    generateTextGeometry();
    addGUIControls();
    function makeInstance(geometry, color, x) {

        const material = new THREE.MeshLambertMaterial({color});

        cube = new THREE.Mesh(geometry, material);
        cube.position.x = x;
        cube.position.y = -2
        cube.castShadow = true;
        scene.add(cube);

        let guiControls = new function() {
            this.color = material.color.getStyle();
            this.wireframe = material.wireframe;
        };

        const folder = gui.addFolder(`Cube${x}`);
        folder.addColor(new ColorGUIHelper(material, 'color'), 'value')
            .name('color')
            .onChange(requestRenderIfNotRequested);
        folder.add(cube.scale, 'x', .1, 1.5)
            .name('scale x')
            .onChange(requestRenderIfNotRequested);
        folder.add(guiControls, "wireframe")
            .onChange(function (e) {
                cube.material.wireframe = e;
            });
        folder.open();


        return cube;
    }
    makeInstance(geometry, 0x44aa88,  0);


    function resizeRendererToDisplaySize(renderer) {
        const canvas = renderer.domElement;
        const width = canvas.clientWidth;
        const height = canvas.clientHeight;
        const needResize = canvas.width !== width || canvas.height !== height;
        if (needResize) {
            renderer.setSize(width, height, false);
        }
        return needResize;
    }

    let renderRequested = false;
    function render() {
        renderRequested = undefined;

        if (resizeRendererToDisplaySize(renderer)) {
            const canvas = renderer.domElement;
            camera.aspect = canvas.clientWidth / canvas.clientHeight;
            camera.updateProjectionMatrix();
        }

        controls.update();
        renderer.render(scene, camera);
    }
    render();

    function requestRenderIfNotRequested() {
        if (!renderRequested) {
            renderRequested = true;
            requestAnimationFrame(render);
        }
    }

    controls.addEventListener('change', requestRenderIfNotRequested);
    window.addEventListener('resize', requestRenderIfNotRequested);

}
function animate() {
    requestAnimationFrame( animate );

    cube.rotation.y += 0.01;
    renderer.render( scene, camera );
}
main();
animate();


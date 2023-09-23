import * as THREE from './build/three.module.js';
import {GLTFLoader} from './examples/jsm/loaders/GLTFLoader.js'
import Stats from './examples/jsm/libs/stats.module.js';
import { GUI } from './examples/jsm/libs/dat.gui.module.js';
import { OrbitControls } from './examples/jsm/controls/OrbitControls.js';
import {PLYLoader} from "./examples/jsm/loaders/PLYLoader.js";
import {JSONLoader} from "./build/three.module.js";

const gui = new GUI();
const loader = new PLYLoader();

let WIDTH, HEIGHT, aspectRatio;
let renderer;
let scene, camera;
let controls;
let mesh;
let groundMesh;
let envcamera;
let cube;


let data = {
    text: "Japanese text is not supported!",
    size: 1.2,
    height: 1.2,
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
]

const weights = [
    'regular',
    'bold'
]

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

function addGUIControls() {

    let textFolder = gui.addFolder('Text');

    textFolder.add(data, 'text').onChange(generateTextGeometry);
    textFolder.add(data, 'size', 0.1, 1).onChange(generateTextGeometry);
    textFolder.add(data, 'height', 0.1, 1).onChange(generateTextGeometry);
    textFolder.add(data, 'curveSegments', 1, 20).onChange(generateTextGeometry);
    textFolder.add(data, 'font', fonts).onChange(generateTextGeometry);
    textFolder.add(data, 'weight', weights).onChange(generateTextGeometry);
    textFolder.add(data, 'bevelEnabled').onChange(generateTextGeometry);
    textFolder.add(data, 'bevelThickness', 0.1, 3).onChange(generateTextGeometry);
    textFolder.add(data, 'bevelSize', 0.1, 3).onChange(generateTextGeometry);


    gui.domElement.style.position = 'absolute';
    gui.domElement.style.top = '0px';
    gui.domElement.style.right = '2px';
    document.body.appendChild(gui.domElement);
}

function addDolphinGUI(){
    let dolphinFolder = gui.addFolder("Dolphin");
    let meshMaterial = new THREE.MeshStandardMaterial({ color: 0x0055ff, flatShading: true,});


    dolphinFolder.addColor(new ColorGUIHelper(meshMaterial, 'color'), 'value')
        .name('color')
        .onChange();

    let guiControls = new function() {
        this.color = meshMaterial.color.getStyle();
        this.wireframe = meshMaterial.wireframe;
    };

    let loader = new PLYLoader();
    loader.load('./examples/models/ply/binary/dolphins_be.ply', function(statue) {
        //geometry.computeVertexNormals();
        let mesh = new THREE.Mesh(statue, meshMaterial);
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

    /*loader.load( 'assets/ballon.glb', function ( gltf ) {
        let stair = gltf.scene;
        stair.castShadow = true;
        scene.add(stair);

    }, undefined, function ( error ) {

        console.error( error );
    });

    loader.load('assets/slb.glb', function (gltf){
        let mesh = new THREE.Mesh(gltf, meshMaterial);
        mesh.scale.multiplyScalar( 0.004 );
        let stair = gltf.scene;
        // mesh.castShadow = true;
        dolphinFolder.add(guiControls, "wireframe")
            .onChange(function (e) {
                mesh.material.wireframe = e;
            });
        scene.add(mesh);
    });*/


}

function addCube(){
    let color = 0x44aa88;
    const material = new THREE.MeshLambertMaterial({color});

    const geometry = new THREE.BoxGeometry(1,1,1);


    cube = new THREE.Mesh(geometry, material);
    cube.position.x = 0;
    cube.position.y = 0;
    cube.castShadow = true;
    scene.add(cube);

    let guiControls = new function() {
        this.color = material.color.getStyle();
        this.wireframe = material.wireframe;
    };

    const folder = gui.addFolder(`Cube`);
    folder.addColor(new ColorGUIHelper(material, 'color'), 'value')
        .name('color')
        .onChange();
    folder.add(cube.scale, 'x', .1, 1.5)
        .name('scale x')
        .onChange();
    folder.add(guiControls, "wireframe")
        .onChange(function (e) {
            cube.material.wireframe = e;
        });
}

function addLights(){
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
}

function addSkybox(){
    let materialArray = [];

    let texture_ft = new THREE.TextureLoader().load('assets/skybox1/')
}
function init() {

    HEIGHT = window.innerHeight;
    WIDTH = window.innerWidth;
    aspectRatio = WIDTH / HEIGHT;

    renderer = new THREE.WebGLRenderer();
    renderer.setSize(WIDTH, HEIGHT);
    renderer.setClearColor(0xcfcfcf);
    //árnyékok bekapcsolása
    renderer.shadowMap.enabled = true;
    renderer.shadowMap.type = THREE.PCFSoftShadowMap;

    document.body.appendChild(renderer.domElement);
    scene = new THREE.Scene();
    camera = new THREE.PerspectiveCamera(75, aspectRatio, 0.1, 1000);
    camera.position.set(0, 0, 40);
    camera.lookAt(scene.position);

    addGUIControls();
    addDolphinGUI();
    addCube();
    generateTextGeometry()
    addLights()

    //Control setup
    controls = new OrbitControls(camera, renderer.domElement);
    controls.enableDamping = true;
    controls.maxDistance = 50;
    controls.minDistance = 1;
    controls.target.set(0, 0, 0);
    controls.update();

    window.addEventListener('resize', handleWindowResize, false);

    reflectionShow();
    render();

}
function reflectionShow(){
    let textureLoader = new THREE.TextureLoader();

    let material = new THREE.MeshBasicMaterial({
        side: THREE.BackSide,
        map: textureLoader.load('assets/desert.jpg')
    });

    let skybox = new THREE.Mesh(new THREE.SphereGeometry(100,128,128), material);
    scene.add(skybox);


    const cubeRenderTarget = new THREE.WebGLCubeRenderTarget(512, {
        format: THREE.RGBFormat,
        generateMipmaps: true,
        minFilter: THREE.LinearMipmapLinearFilter
    });

    envcamera = new THREE.CubeCamera(1, 1000, cubeRenderTarget);
    envcamera.position.set(0,-5,0);
    scene.add(envcamera);


    // generateTextGeometry();
    let gGeometry= new THREE.PlaneGeometry(30,30);
    let gMaterial = new THREE.MeshPhongMaterial({
        color: 0xcccccc,
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
}

function generateTextGeometry() {
    let loader = new THREE.FontLoader();
    loader.load('./fonts/' + data.font + '_' + data.weight + '.typeface.json', (font) => {//
        let geometry = new THREE.TextGeometry(data.text, {
            font: font,
            size: data.size,
            height: data.height,
            curveSegments: data.curveSegments,
            bevelEnabled: data.bevelEnabled,
            bevelThickness: data.bevelThickness,
            bevelSize: data.bevelSize
        });
        geometry.center();

        if (!mesh) {
            let textMaterial = new THREE.MeshPhongMaterial({color: 0xcfcfcf, wireframe: false, transparent: false});//
            mesh = new THREE.Mesh(geometry, textMaterial);
            scene.add(mesh);
        } else {
            mesh.geometry.dispose();
            mesh.geometry = geometry;
        }
        mesh.castShadow=true;
        mesh.position.set(-4,0,0);
        mesh.rotation.y = 0.2;

    })
}

function render(){
    groundMesh.visible = false;
    envcamera.update(renderer, scene);
    groundMesh.visible = true;

    cube.rotation.y += 0.01;
    requestAnimationFrame(render);
    controls.update();
    renderer.render(scene, camera);
}

function handleWindowResize(){
    HEIGHT = window.innerHeight;
    WIDTH = window.innerWidth;

    renderer.setSize(WIDTH,HEIGHT);
    aspectRatio = WIDTH/HEIGHT;
    camera.aspectRatio=aspectRatio;
    camera.updateProjectionMatrix();
}

init();



<?php
    $videos = array();
    $thumbnails = array();
    $background360 = array();
    foreach (glob('assets/video/*.mp4') as $filename) {
        $p = pathinfo($filename);
        $videos[] = $p['filename']. '.' .$p['extension'];
    }

foreach (glob('assets/thumbnail/*.jpg') as $filename) {
    $p = pathinfo($filename);
    $thumbnails[] = $p['filename']. '.' .$p['extension'];
}
foreach (glob('assets/background/*.*') as $filename) {
    $p = pathinfo($filename);
    $background360[] = $p['filename']. '.' .$p['extension'];
}
$script="
export function videos() {
    return". json_encode($videos). ";
}
export function thumbnails() {
    return". json_encode($thumbnails). ";
}
export function panoramas() {
    return". json_encode($background360). ";
}
";
$fileName="js/files.js";
file_put_contents($fileName, $script);

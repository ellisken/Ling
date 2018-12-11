/* Tutorial to get started with Recorder.js
 * https://addpipe.com/blog/using-recorder-js-to-capture-wav-audio-in-your-html5-web-site/
*/

/* Variables */

// Stream from getUserMedia()
let getUserMediaStream;
// Recorder.js object
let recording;
// MediaStreamAudioSourceNode we will be recording
let input;

// Shim for AudioContext when it's not audio video bridging. Shims allow for backwards compatibility by intercepting API calls and providing a layer of abstraction between a caller and a target.
let AudioContext = window.AudioContext || webkit.AudioContext;
// New audio context that helps us record
let audioContext = new AudioContext;

// Grab DOM elements
const recordButton = document.getElementById("record-button");
const pauseButton = document.getElementById("pause-button");
const stopButton = document.getElementById("stop-button");

// Attach event listeners
recordButton.addEventListener("click", startRecording);
pauseButton.addEventListener("click", pauseRecording);
stopButton.addEventListener("click", stopRecording);

function startRecording() {
    console.log("start recording has been clicked!");

    // Disable the record button until getUserMedia() returns a success or fail
    recordButton.disabled = true;
    stopButton.disabled = false;
    pauseButton.disables = false;

    /*
      getUserMedia() is a promise-based method prompts the user for permission to use a a media input, which produces a MediaStream object with a specified list of a/v tracks. In our case, the stream wil have an audio track.
        https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia
    */

    // Set request permissions for only audio
    const constraints = { audio: true, video: false };


}

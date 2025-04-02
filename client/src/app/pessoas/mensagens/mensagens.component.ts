import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-mensagens',
  imports: [],
  templateUrl: './mensagens.component.html',
  styleUrl: './mensagens.component.css'
})
export class MensagensComponent implements OnInit {
  ngOnInit(): void {
    let peerConnection = new RTCPeerConnection();
    let signalingServer = new WebSocket('ws://localhost:8080');

    navigator.mediaDevices.getUserMedia({ video: true, audio: true })
      .then(function (stream) {
        let videoElement = document.getElementById('localVideo') as HTMLVideoElement
        videoElement.srcObject = stream;

        stream.getTracks().forEach(track => peerConnection.addTrack(track, stream));
      })
      .catch(function (error) {
        console.error('Error accessing media devices.', error);
      });

      peerConnection.onicecandidate = function(event) {
        if (event.candidate) {
            signalingServer.send(JSON.stringify({ 'candidate': event.candidate }));
        }
    };

    peerConnection.ontrack = function(event) {
      let remoteVideo = document.getElementById('remoteVideo') as HTMLVideoElement
      remoteVideo.srcObject = event.streams[0];
  };


  }
}

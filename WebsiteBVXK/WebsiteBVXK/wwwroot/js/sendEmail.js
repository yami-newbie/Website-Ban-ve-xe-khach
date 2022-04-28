// Import the functions you need from the SDKs you need
import { initializeApp } from "https://www.gstatic.com/firebasejs/9.6.11/firebase-app.js";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
const firebaseConfig = {
    apiKey: "AIzaSyAltDidh8M973mKiGw5SXmNDDlNk8ryyRk",
    authDomain: "websitebvxk.firebaseapp.com",
    projectId: "websitebvxk",
    storageBucket: "websitebvxk.appspot.com",
    messagingSenderId: "60611691795",
    appId: "1:60611691795:web:ec4f32b033bd88093646e6"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);



function sendEmail() {
    Email.send({
        Host: "smtp.mailtrap.io",
        Username: "3e4ed6765183a5",
        Password: "4a17e9855d33b8",
        To: 'recipient@example.com',
        From: "sender@example.com",
        Subject: "Test email",
        Body: "<html><h2>Header</h2><strong>Bold text</strong><br></br><em>Italic</em></html>"
    }).then(
        message => alert(message)
    );
}
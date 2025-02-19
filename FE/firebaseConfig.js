import { initializeApp } from "firebase/app";
import { getAuth, GoogleAuthProvider } from "firebase/auth";

const firebaseConfig = {
  apiKey: "AIzaSyBtedx9jynW5rePk2FmaIiTQStf2di1TRQ",
  authDomain: "authenticate-be518.firebaseapp.com",
  projectId: "authenticate-be518",
  storageBucket: "authenticate-be518.firebasestorage.app",
  messagingSenderId: "827004123339",
  appId: "1:827004123339:web:853464747a38503723834e",
  measurementId: "G-NVVM62H70F"
};

// Khởi tạo Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);
const googleProvider = new GoogleAuthProvider();

export { auth, googleProvider };

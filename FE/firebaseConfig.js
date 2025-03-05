import { initializeApp } from "firebase/app";
import { getAuth, GoogleAuthProvider } from "firebase/auth";

const firebaseConfig = {
  apiKey: "AIzaSyCqL1JoXfUmBpf1I_73ilIkAhGAyjo_leo",
  authDomain: "metrosystem-afac0.firebaseapp.com",
  projectId: "metrosystem-afac0",
  storageBucket: "metrosystem-afac0.appspot.com",
  messagingSenderId: "35398002780",
  appId: "1:35398002780:web:d3edff957d413e8aef1e99",
  measurementId: "G-MNP1WS3GV2"
};

// Khởi tạo Firebase
const app = initializeApp(firebaseConfig);
const auth = getAuth(app);
const googleProvider = new GoogleAuthProvider();

export { auth, googleProvider };
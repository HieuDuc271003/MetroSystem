import { Routes, Route, Navigate } from "react-router-dom";
import Login from "../../auth/login/Login";
import Register from "../../auth/register/Register";


const Auth = () => {
  return (
    <div>
      <Routes>
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        <Route path="*" element={<Navigate to="/auth/login" />} />
      </Routes>
      
    </div>
  );
};

export default Auth;

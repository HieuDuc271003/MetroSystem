import React, { useState } from "react";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import { FcGoogle } from "react-icons/fc"; // Icon Google
import { auth, googleProvider } from "../../../../firebaseConfig";
import { signInWithPopup } from "firebase/auth";
import BackgroundLogin from "../../../assets/bg2.avif";

export default function Login() {
  const [showPassword, setShowPassword] = useState(false);
  const [user, setUser] = useState(null); // Lưu trạng thái đăng nhập
  const [loading, setLoading] = useState(false); // Xử lý trạng thái tải

  // Xử lý đăng nhập Google
  const handleGoogleSignIn = async () => {
    try {
      setLoading(true);
      const result = await signInWithPopup(auth, googleProvider);
      const idToken = await result.user.getIdToken();

      const userInfo = {
        firebaseUid: result.user.uid,
        email: result.user.email,
        name: result.user.displayName,
        idToken: idToken, // 🔥 Gửi ID Token lên Backend  
      };

      console.log("Google User Info:", userInfo);

      const response = await fetch("https://localhost:7225/api/auth/google-login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(userInfo),
      });

      const data = await response.json();
      if (!response.ok) {
        throw new Error(data.message || "Xác thực Google thất bại");
      }

      // Lưu token vào localStorage để sử dụng cho API khác
      localStorage.setItem("token", data.token);
      localStorage.setItem("refreshToken", data.refreshToken);

      setUser(result.user);
      console.log("Đăng nhập thành công:", data);
    } catch (error) {
      alert("Đăng nhập thất bại: " + error.message); // ✅ Thông báo lỗi
      console.error("Lỗi đăng nhập Google:", error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div
      className="w-full h-screen flex items-center justify-center relative bg-cover bg-center"
      style={{ backgroundImage: `url(${BackgroundLogin})` }}
    >
      <div className="bg-black bg-opacity-30 w-full h-full absolute top-0 left-0"></div>
      <div className="z-10 bg-white bg-opacity-40 p-6 rounded-lg shadow-lg w-[350px]">
        <h2 className="text-2xl font-bold text-center mb-4 text-black">
          {user ? `Chào, ${user.displayName}!` : "Đăng nhập"}
        </h2>
        {user ? (
          <div className="text-center">
            {<img
              src={user.photoURL}
              alt="User Avatar"
              className="w-16 h-16 rounded-full mx-auto mb-2"
            />}
            <p className="text-black">{user.email}</p>
          </div>
        ) : (
          <>
            <input
              type="text"
              placeholder="Tên đăng nhập"
              className="w-full px-4 py-2 mb-3 border text-black border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
            />
            <div className="relative">
              <input
                type={showPassword ? "text" : "password"}
                placeholder="Mật khẩu"
                className="w-full px-4 py-2 mb-3 border text-black border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
              />
              <button
                type="button"
                className="absolute inset-y-0 -top-3 right-3 flex items-center"
                onClick={() => setShowPassword(!showPassword)}
              >
                {showPassword ? (
                  <FaEye className="w-5 h-5 text-gray-500" />
                ) : (
                  <FaEyeSlash className="w-5 h-5 text-gray-500" />
                )}
              </button>
            </div>
            <button className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition">
              Đăng nhập
            </button>
            <button
              className="w-full mt-3 flex items-center justify-center bg-white border py-2 rounded-lg shadow-md hover:bg-gray-100 transition"
              onClick={handleGoogleSignIn}
              disabled={loading} // Vô hiệu hóa nút khi đang tải
            >
              <FcGoogle className="w-6 h-6 mr-2" />
              <span className="text-black">
                {loading ? "Đang đăng nhập..." : "Đăng nhập với Google"}
              </span>
            </button>
          </>
        )}
      </div>
    </div>
  );
}

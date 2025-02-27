import React, { useState } from "react";
import { FaEye, FaEyeSlash } from "react-icons/fa";
import BackgroundRegister from "../../../assets/bg2.avif";

export default function Register() {
  const [showPassword, setShowPassword] = useState(false);
  const [showConfirmPassword, setShowConfirmPassword] = useState(false);

  return (
    <div
      className="w-full h-screen flex items-center justify-center relative bg-cover bg-center"
      style={{ backgroundImage: `url(${BackgroundRegister})` }}
    >
      {/* Overlay mờ 30% */}
      <div className="bg-black bg-opacity-30 w-full h-full absolute top-0 left-0"></div>

      {/* Form đăng ký */}
      <div className="z-10 bg-white bg-opacity-40 p-6 rounded-lg shadow-lg w-[350px]">
        <h2 className="text-2xl font-bold text-center mb-4 text-black">Đăng ký</h2>

        <input
          type="text"
          placeholder="Tên đăng nhập"
          className="w-full px-4 py-2 mb-3 border text-black border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />

        <input
          type="email"
          placeholder="Email"
          className="w-full px-4 py-2 mb-3 border text-black border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
        />

        {/* Ô nhập mật khẩu */}
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

        {/* Ô xác nhận mật khẩu */}
        <div className="relative">
          <input
            type={showConfirmPassword ? "text" : "password"}
            placeholder="Xác nhận mật khẩu"
            className="w-full px-4 py-2 mb-3 border text-black border-gray-300 rounded-lg focus:outline-none focus:ring-2 focus:ring-blue-500"
          />
          <button
            type="button"
            className="absolute inset-y-0 -top-3 right-3 flex items-center"
            onClick={() => setShowConfirmPassword(!showConfirmPassword)}
          >
            {showConfirmPassword ? (
              <FaEye className="w-5 h-5 text-gray-500" />
            ) : (
              <FaEyeSlash className="w-5 h-5 text-gray-500" />
            )}
          </button>
        </div>

        <button className="w-full bg-blue-600 text-white py-2 rounded-lg hover:bg-blue-700 transition">
          Đăng ký
        </button>
      </div>
    </div>
  );
}

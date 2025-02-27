import React from "react";
import { Route, Routes, Navigate } from "react-router-dom";
import Overview from "../../admin_pages/overview/Overview";
import Sidebar  from "../../admin_pages/sidebar/Sidebar";
// import Navbarr from "../../admin_pages/navbar/Navbar";

export default function Admin() {
  return (
    <div className="flex h-screen bg-gray-900 text-gray-100 overflow-hidden">
      {/* Background */}
      
      {/* Sidebar */}
      <Sidebar />

      {/* Nội dung chính */}
     
        {/* Navbar */}
        {/* <div className="  text-white">
        <Navbarr/>
        </div> */}

        {/* Nội dung bên dưới navbar */}    
          <Routes>
            <Route path="overview" element={<Overview />} />
            <Route path="*" element={<Navigate to="/admin/overview" />} />
          </Routes>
      </div>

  );
}

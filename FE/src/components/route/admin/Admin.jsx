<<<<<<< HEAD
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
=======
// import React from "react";
// import { Route, Routes, Navigate } from "react-router-dom";
// import Overview from "../../admin_pages/overview/Overview";
// import Sidebar  from "../../admin_pages/sidebar/Sidebar";
// import Header from "../../admin_pages/header_admin/Header";
// // import Navbarr from "../../admin_pages/navbar/Navbar";

// export default function Admin() {
//   return (
//     <div className="flex h-screen bg-gray-900 text-gray-100 overflow-hidden">
//       {/* Background */}
//       <Routes>
//             <Route path="sidebar" element={<Sidebar />} />
//             <Route path="sidebar" element={<Navigate to="/admin/sidebar" />} />
//       </Routes>
//       {/* Sidebar */}
//       <Sidebar />

//       {/* Nội dung chính */}
     
//         {/* Navbar */}
//         {/* <div className="  text-white">
//         <Navbarr/>
//         </div> */}

//         {/* Nội dung bên dưới navbar */}    
//           <Routes>
//             <Route path="overview" element={<Overview />} />
//             <Route path="overview" element={<Navigate to="/admin/overview" />} />
//           </Routes>

            
//       </div>

//   );
// }

import React, { useEffect, useState } from "react";
import { Route, Routes, Navigate } from "react-router-dom";
import Overview from "../../admin_pages/overview/Overview";
import Sidebar from "../../admin_pages/sidebar/Sidebar";
import Header from "../../admin_pages/header_admin/Header";
import NavbarPage from "../../admin_pages/navbar/Navbar"; // Create a separate page for Navbar
import SalesChannelChart from "../../admin_pages/salesChanel/SalesChannelChart";
import SalesOverviewChart from "../../staff_pages/salesOverviewStaff/SalesOverviewChart";
import CategoryDistributionChart from "../../admin_pages/category/CategoryDistributionChart";
import StatCard from "../../admin_pages/statcard/StatCard";
import UserManagement from "../../admin_pages/userManagement/UserManagement";

export default function Admin() {
  const [userCount, setUserCount] = useState(0);
  // const [userRole, setUserRole] = useState(null);
  // const navigate = useNavigate();

  // useEffect(() => {
  //   const userData = JSON.parse(localStorage.getItem("user")); // Assume user data is stored in localStorage
  //   if (!userData || userData.role !== "Admin") {
  //     navigate("/unauthorized"); // Redirect if not an Admin
  //   } else {
  //     setUserRole(userData.role);
  //   }
  // }, [navigate]);

  // Fetching data from a public API (example: JSONPlaceholder)
  useEffect(() => {
    fetch("https://metroldirection.azurewebsites.net/api/admin/users")
      .then((response) => response.json())
      .then((data) => setUserCount(data.length)) // Counting total users
      .catch((error) => console.error("Error fetching user data:", error));
  }, []);

  return (
    <div className="flex h-screen bg-gray-900 text-gray-100 overflow-hidden">
      {/* Sidebar */}
      <Sidebar />

      {/* Main Content */}
      <div className="flex-1 flex flex-col overflow-auto">
        {/* Header */}
        <Header title={`Dashboard - ${userCount} Users`} />

        {/* Routes */}
        <div className="p-6">
          <Routes>
            <Route path="overview" element={<Overview />} />
            <Route path="navbar" element={<NavbarPage />} />
            <Route path="saleschannelchart" element={<SalesChannelChart />} />
            <Route path="salesoverviewchart" element={<SalesOverviewChart />} />
            <Route path="categorydistributionchart" element={<CategoryDistributionChart />} />
            <Route path="sidebar" element={<Sidebar />} />
            <Route path="statcard" element={<StatCard />} />
            <Route path="usermanagement" element={<UserManagement />} />
            <Route path="*" element={<Navigate to="/admin/overview" />} />
          </Routes>
        </div>
      </div>
    </div>
  );
}

>>>>>>> e644d97 (Adjust the Admin Pages)

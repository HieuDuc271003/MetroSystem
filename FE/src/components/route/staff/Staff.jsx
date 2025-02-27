import React from 'react'
import { Routes, Route, Navigate } from 'react-router-dom'
import OverviewStaff from '../../staff_pages/overviewStaff/OverviewStaff'
import Sidebar  from "../../staff_pages/sidebarStaff/Sidebar";

export default function Staff() {
  return (
    <div className="flex h-screen bg-gray-900 text-gray-100 overflow-hidden">
      {/* Sidebar staff */}
      <Sidebar/>
        <Routes>
            <Route path="overview" element={<OverviewStaff />} />
            <Route path="*" element={<Navigate to="/staff/overview" />} />
        </Routes>
    </div>
  )
}

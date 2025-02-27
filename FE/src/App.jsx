import React from 'react';
import { BrowserRouter as Router, Routes, Route } from 'react-router-dom';
import Navbar from './pages/navbar/Navbar';
import Footer from './components/footer/Footer';
import HomeContainer from './pages/home_container/HomeContainer';
import Bus from './pages/bus/Bus';
import Auth from './components/route/auth/Auth';
import Admin from './components/route/admin/Admin';
import Staff from './components/route/staff/Staff';
import Chatbot from './components/chatbot/Chatbot';
import SearchBus from './components/Searchbus';

function App() {
  const isAdminPage = location.pathname.startsWith('/admin');
  const isStaffPage = location.pathname.startsWith('/staff')
  const hihi = location.pathname.startsWith('/searchbus')
  return (
    <>
      <Router>
      <div className='w-full min-h-screen bg-neutral-50 dark:bg-neutral-950 text-neutral-800 dark:text-neutral-300 flex flex-col overflow-hidden'>
      {!(isAdminPage || isStaffPage || hihi) && <Navbar />} {/* Chỉ hiển thị Navbar nếu không phải trang admin */}

      <Routes>
        {/* Trang chủ */}
        <Route path="/" element={<HomeContainer />} />

       <Route path="/searchbus" element={<SearchBus/>} /> 

        {/* Trang đến xe bus */}
        <Route path="/bus" element={<Bus />} />

         {/* Trang đến chat bot */}
         <Route path='/chatbot' element={<Chatbot/>}></Route>

        {/* Trang đến đăng nhập , đăng ký */}
        <Route path="/auth/*" element={<Auth />} />


        {/* Trang đến admin */}
        <Route path="/admin/*" element={<Admin />} />

        {/* Trang đến staff */}
        <Route path='/staff/*' element={<Staff/>} />
      </Routes>

      {!(isAdminPage || isStaffPage ||hihi) && <Footer />} {/* Chỉ hiển thị Footer nếu không phải trang admin */}
    </div>
      </Router>
    </>
  )
}

export default App

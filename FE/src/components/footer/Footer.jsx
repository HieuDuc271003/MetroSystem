import React from 'react'
import { FaMapPin } from 'react-icons/fa6'
import { Link } from 'react-router-dom'

import Logo from "../../assets/logo.png";

const Footer = () => {
  return (
    <footer className="w-full lg:px-28 md:px-16 sm:px-7 px-4 py-8 bg-neutral-200/60 dark:bg-neutral-900/70">
      <div className="grid grid-cols-5 gap-5">
        <div className="space-y-5 col-span-2">
          <Link to="/" className='text-xl text-neutral-800 dark:text-neutral-200 font-bold'>
            <img src={Logo} alt="logo" className="w-44 h-auto object-contain" />
          </Link>
          <p className="text-neutral-600 dark:text-neutral-500 text-base font-normal pr-10">
            Chúng tôi cam kết mang đến dịch vụ tốt nhất với sự tận tâm và chuyên nghiệp. Hãy đồng hành cùng chúng tôi để có những trải nghiệm tuyệt vời nhất.
          </p>
        </div>

        <div className="space-y-7">
          <h1 className="text-lg font-medium">Về Chúng Tôi</h1>
          <ul className="space-y-2 text-neutral-600 dark:text-neutral-500 text-base font-normal">
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Giới thiệu</Link>
            </li>
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Liên hệ</Link>
            </li>
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Chính sách bảo mật</Link>
            </li>
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Điều khoản & Điều kiện</Link>
            </li>
          </ul>
        </div>

        <div className="space-y-7">
          <h1 className="text-lg font-medium">Dịch Vụ</h1>
          <ul className="space-y-2 text-neutral-600 dark:text-neutral-500 text-base font-normal">
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Đảm bảo an toàn</Link>
            </li>
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Câu hỏi thường gặp</Link>
            </li>
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Xe cao cấp</Link>
            </li>
            <li>
              <Link to="#" className='hover:text-violet-600 ease-in-out duration-300'>Tiện nghi đầy đủ</Link>
            </li>
          </ul>
        </div>

        <div className="space-y-7">
          <h1 className="text-lg font-medium">Liên Hệ</h1>
          <div className="space-y-4">
            <div className="flex gap-x-2">
              <FaMapPin className='text-2xl text-neutral-600 dark:text-neutral-500' />
              <div className="flex flex-col">
                <p className="text-xs text-neutral-600 dark:text-neutral-500">
                  Hỗ trợ & Đặt lịch
                </p>
                <p className="text-sm text-neutral-700 dark:text-neutral-400">
                  123, Đường Chính, TP. Hồ Chí Minh, Việt Nam
                </p>
              </div>
            </div>

            <div className="flex gap-x-2">
              <FaMapPin className='text-2xl text-neutral-600 dark:text-neutral-500' />
              <div className="flex flex-col">
                <p className="text-xs text-neutral-600 dark:text-neutral-500">
                  Tổng đài hỗ trợ
                </p>
                <p className="text-sm text-neutral-700 dark:text-neutral-400">
                  (+84) 123 456 789
                </p>
              </div>
            </div>

            <div className="flex gap-x-2">
              <FaMapPin className='text-2xl text-neutral-600 dark:text-neutral-500' />
              <div className="flex flex-col">
                <p className="text-xs text-neutral-600 dark:text-neutral-500">
                  Email hỗ trợ
                </p>
                <p className="text-sm text-neutral-700 dark:text-neutral-400">
                  support@website.com
                </p>
              </div>
            </div>
          </div>
        </div>

      </div>
    </footer>
  )
}

export default Footer;

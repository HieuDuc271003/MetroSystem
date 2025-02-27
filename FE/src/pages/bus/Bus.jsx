import React from 'react'
import Bus1 from '../../assets/bus1.png'
import { Link } from 'react-router-dom'
import { CiSearch } from "react-icons/ci";

export default function Bus() {
  return (
    <div className='w-full lg:px-28 md:px-16 sm:px-7 px-4 mt-[13ch] mb-[8ch]'>
        {/* Tìm kiếm và bộ lọc */}
        <div className="w-full grid grid-cols-6 gap-14 bg-neutral-200/60 dark:bg-neutral-900/40 rounded-md px-6 py-5 items-center justify-between">
          <div className="flex items-center gap-x-2.5 col-span-2">
            <input 
              type="text" 
              placeholder='Tìm kiếm xe buýt' 
              id='seat' 
              name='seat'
              className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900" 
            />
            <button className="bg-violet-600 h-11 px-4 rounded-md text-base text-neutral-50 font-normal">
               <CiSearch />
            </button>
          </div>
          <div className="col-span-2"></div>

          <div className="col-span-2">
            <select className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900">
                <option value="">Chọn loại xe buýt</option>
                <option value="Bus">Xe buýt</option>
                <option value="Metro">Tàu điện</option>
                <option value="Bus elecetronic">Xe buýt điện</option>
            </select>
          </div>
        </div>

        {/* Danh sách xe buýt */}
        <div className="w-full grid grid-cols-3 gap-10 mt-10">
          {[...Array(6)].map((_, index) => (
            <Link key={index} to={"/bus/bus-details"} className="w-full bg-neutral-200/60 block dark:bg-neutral-900/40 rounded-xl p-4">
              <img src={Bus1} alt="Hình ảnh xe buýt" className="w-full aspect-video object-contain object-center" />
              <div className="px-3 py-4 space-y-2">
                <div className="flex items-center justify-between">
                    <h1 className="text-xl font-semibold text-neutral-800 dark:text-neutral-50">
                        Xe buýt du lịch
                    </h1>
                    <p className="text-sm font-normal text-neutral-800 dark:text-neutral-50">
                        60 hành khách
                    </p>
                </div>
              </div>
            </Link>
          ))}
        </div>
    </div>
  )
}

import React from 'react'
import { CiSearch } from "react-icons/ci";

export default function Navbarr() {
  return (
    <div className=''>
       <div className='w-full rounded-none bg-gray-900 '>
               {/* Search and filter */}
               <div className="w-full grid grid-cols-6 gap-14 bg-gray-900 dark:bg-gray-900 rounded-md px-6 py-5 items-center justify-between">
                 <div className="flex items-center gap-x-2.5 col-span-2">
                 <input type="text" placeholder='Search' className="w-full appearance-none text-black placeholder:text-white bg-gray-800 inline-block dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200  rounded-md focus:outline-none focus:placeholder:text-black focus:bg-neutral-100 dark:focus:bg-neutral-900" />
                   <button className="bg-violet-600 h-11 px-4 rounded-md text-base text-white font-normal">
                       {/* Icon search */}
                      <CiSearch />
                   </button>
                 </div>
               
               </div>
       </div>
    </div>
  )
}

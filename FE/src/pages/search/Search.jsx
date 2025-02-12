import React from 'react';

export default function Search() {
  return (
    <div className='w-full lg:px-28 md:px-16 sm:px-7 px-4 my-[8ch]'>
      <div className="w-full bg-neutral-100 rounded-md dark:bg-neutral-900/40 p-8">
        <div className="grid grid-cols-3 gap-x-10 gap-y-12 items-end">
          
          <div className="">
            <label htmlFor="from" className="block mb-2 font-semibold">
              Điểm đi
            </label>
            <select name="from" id="from" className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900">
              <option value="">Chọn địa điểm</option>
              <option value="location1">Địa điểm 1</option>
              <option value="location2">Địa điểm 2</option>
              <option value="location3">Địa điểm 3</option>
            </select>
          </div>

          <div className="">
            <label htmlFor="to" className="block mb-2 font-semibold">
              Điểm đến
            </label>
            <select name="to" id="to" className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900">
              <option value="">Chọn địa điểm</option>
              <option value="location4">Địa điểm 4</option>
              <option value="location5">Địa điểm 5</option>
              <option value="location6">Địa điểm 6</option>
            </select>
          </div>

          <div className="">
            <label htmlFor="date" className="block mb-2 font-semibold">
              Chọn ngày
            </label>
            <input type="date" id="date" name="date" className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900" />
          </div>

          <div className="">
            <label htmlFor="time" className="block mb-2 font-semibold">
              Chọn giờ
            </label>
            <input type="time" id="time" name="time" className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900" />
          </div>

          <div className="">
            <label htmlFor="seat" className="block mb-2 font-semibold">
              Số ghế
            </label>
            <input type="number" placeholder="Nhập số ghế" id="seat" name="seat" className="w-full appearance-none text-neutral-900 placeholder:text-neutral-400 dark:text-neutral-100 inline-block bg-neutral-200/60 dark:bg-neutral-900/60 px-3 h-12 border border-neutral-200 dark:border-neutral-900 rounded-md focus:outline-none focus:bg-neutral-100 dark:focus:bg-neutral-900" />
          </div>

          <div className="">
            <button className="w-full px-4 h-12 bg-violet-600 text-neutral-50 text-base font-normal rounded-md">
              Kiểm tra chỗ trống
            </button>
          </div>

        </div>
      </div>
    </div>
  );
}

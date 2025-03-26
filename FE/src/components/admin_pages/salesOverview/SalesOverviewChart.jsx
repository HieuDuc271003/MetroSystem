<<<<<<< HEAD
import { motion } from "framer-motion";
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from "recharts";
import { useState } from "react";

const duLieuDoanhSo = [
	{ thang: "Tháng 1", doanhSo: 4000 },
	{ thang: "Tháng 2", doanhSo: 3000 },
	{ thang: "Tháng 3", doanhSo: 5000 },
	{ thang: "Tháng 4", doanhSo: 4500 },
	{ thang: "Tháng 5", doanhSo: 6000 },
	{ thang: "Tháng 6", doanhSo: 5500 },
	{ thang: "Tháng 7", doanhSo: 7000 },
];

const BieuDoTongQuanDoanhSo = () => {
	const [phamViThoiGian, setPhamViThoiGian] = useState("Tháng này");

	return (
		<motion.div
			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700 mb-8'
			initial={{ opacity: 0, y: 20 }}
			animate={{ opacity: 1, y: 0 }}
			transition={{ delay: 0.2 }}
		>
			<div className='flex items-center justify-between mb-6'>
				<h2 className='text-xl font-semibold text-gray-100'>Tổng Quan Doanh Số</h2>

				<select
					className='bg-gray-700 text-white rounded-md px-3 py-1 focus:outline-none focus:ring-2 
          focus:ring-blue-500'
					value={phamViThoiGian}
					onChange={(e) => setPhamViThoiGian(e.target.value)}
				>
					<option>Tuần này</option>
					<option>Tháng này</option>
					<option>Quý này</option>
					<option>Năm nay</option>
				</select>
			</div>

			<div className='w-full h-80'>
				<ResponsiveContainer>
					<AreaChart data={duLieuDoanhSo}>
						<CartesianGrid strokeDasharray='3 3' stroke='#374151' />
						<XAxis dataKey='thang' stroke='#9CA3AF' />
						<YAxis stroke='#9CA3AF' />
						<Tooltip
							contentStyle={{ backgroundColor: "rgba(31, 41, 55, 0.8)", borderColor: "#4B5563" }}
							itemStyle={{ color: "#E5E7EB" }}
						/>
						<Area type='monotone' dataKey='doanhSo' stroke='#8B5CF6' fill='#8B5CF6' fillOpacity={0.3} />
					</AreaChart>
				</ResponsiveContainer>
			</div>
		</motion.div>
	);
};
export default BieuDoTongQuanDoanhSo;
=======
// import { motion } from "framer-motion";
// import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from "recharts";
// import { useState } from "react";

// const duLieuDoanhSo = [
// 	{ thang: "Tháng 1", doanhSo: 4000 },
// 	{ thang: "Tháng 2", doanhSo: 3000 },
// 	{ thang: "Tháng 3", doanhSo: 5000 },
// 	{ thang: "Tháng 4", doanhSo: 4500 },
// 	{ thang: "Tháng 5", doanhSo: 6000 },
// 	{ thang: "Tháng 6", doanhSo: 5500 },
// 	{ thang: "Tháng 7", doanhSo: 7000 },
// ];

// const BieuDoTongQuanDoanhSo = () => {
// 	const [phamViThoiGian, setPhamViThoiGian] = useState("Tháng này");

// 	return (
// 		<motion.div
// 			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700 mb-8'
// 			initial={{ opacity: 0, y: 20 }}
// 			animate={{ opacity: 1, y: 0 }}
// 			transition={{ delay: 0.2 }}
// 		>
// 			<div className='flex items-center justify-between mb-6'>
// 				<h2 className='text-xl font-semibold text-gray-100'>Tổng Quan Doanh Số</h2>

// 				<select
// 					className='bg-gray-700 text-white rounded-md px-3 py-1 focus:outline-none focus:ring-2 
//           focus:ring-blue-500'
// 					value={phamViThoiGian}
// 					onChange={(e) => setPhamViThoiGian(e.target.value)}
// 				>
// 					<option>Tuần này</option>
// 					<option>Tháng này</option>
// 					<option>Quý này</option>
// 					<option>Năm nay</option>
// 				</select>
// 			</div>

// 			<div className='w-full h-80'>
// 				<ResponsiveContainer>
// 					<AreaChart data={duLieuDoanhSo}>
// 						<CartesianGrid strokeDasharray='3 3' stroke='#374151' />
// 						<XAxis dataKey='thang' stroke='#9CA3AF' />
// 						<YAxis stroke='#9CA3AF' />
// 						<Tooltip
// 							contentStyle={{ backgroundColor: "rgba(31, 41, 55, 0.8)", borderColor: "#4B5563" }}
// 							itemStyle={{ color: "#E5E7EB" }}
// 						/>
// 						<Area type='monotone' dataKey='doanhSo' stroke='#8B5CF6' fill='#8B5CF6' fillOpacity={0.3} />
// 					</AreaChart>
// 				</ResponsiveContainer>
// 			</div>
// 		</motion.div>
// 	);
// };
// export default BieuDoTongQuanDoanhSo;


import { motion } from "framer-motion";
import { AreaChart, Area, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer } from "recharts";
import { useEffect, useState } from "react";

const BieuDoTongQuanDoanhSo = () => {
  const [salesData, setSalesData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);
  const [phamViThoiGian, setPhamViThoiGian] = useState("Tháng này");

  // Fetch sales data from a public API
  useEffect(() => {
    fetch("https://fakestoreapi.com/products")
      .then((response) => response.json())
      .then((data) => {
        // Simulating sales distribution per month
        const salesPerMonth = data.slice(0, 7).map((item, index) => ({
          thang: `Tháng ${index + 1}`,
          doanhSo: item.price * (10 + index * 5), // Generate sales based on price
        }));
        setSalesData(salesPerMonth);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching sales data:", err);
        setError("Failed to load sales data");
        setLoading(false);
      });
  }, []);

  return (
    <motion.div
      className="bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700 mb-8"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ delay: 0.2 }}
    >
      <div className="flex items-center justify-between mb-6">
        <h2 className="text-xl font-semibold text-gray-100">Tổng Quan Doanh Số</h2>

        <select
          className="bg-gray-700 text-white rounded-md px-3 py-1 focus:outline-none focus:ring-2 
          focus:ring-blue-500"
          value={phamViThoiGian}
          onChange={(e) => setPhamViThoiGian(e.target.value)}
        >
          <option>Tuần này</option>
          <option>Tháng này</option>
          <option>Quý này</option>
          <option>Năm nay</option>
        </select>
      </div>

      <div className="w-full h-80">
        {loading ? (
          <p className="text-white text-center">Loading data...</p>
        ) : error ? (
          <p className="text-red-500 text-center">{error}</p>
        ) : (
          <ResponsiveContainer>
            <AreaChart data={salesData}>
              <CartesianGrid strokeDasharray="3 3" stroke="#374151" />
              <XAxis dataKey="thang" stroke="#9CA3AF" />
              <YAxis stroke="#9CA3AF" />
              <Tooltip
                contentStyle={{ backgroundColor: "rgba(31, 41, 55, 0.8)", borderColor: "#4B5563" }}
                itemStyle={{ color: "#E5E7EB" }}
              />
              <Area type="monotone" dataKey="doanhSo" stroke="#8B5CF6" fill="#8B5CF6" fillOpacity={0.3} />
            </AreaChart>
          </ResponsiveContainer>
        )}
      </div>
    </motion.div>
  );
};

export default BieuDoTongQuanDoanhSo;

>>>>>>> e644d97 (Adjust the Admin Pages)

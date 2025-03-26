<<<<<<< HEAD
import { motion } from "framer-motion";
import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, Legend, Cell } from "recharts";

const COLORS = ["#6366F1", "#8B5CF6", "#EC4899", "#10B981", "#F59E0B"];

const SALES_CHANNEL_DATA = [
	{ "name": "Trang web", "value": 45600 },
{ "name": "Ứng dụng di động", "value": 38200 },
{ "name": "Sàn thương mại", "value": 29800 },
{ "name": "Mạng xã hội", "value": 18700 },
];

const SalesChannelChart = () => {
	return (
		<motion.div
			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 lg:col-span-2 border border-gray-700'
			initial={{ opacity: 0, y: 20 }}
			animate={{ opacity: 1, y: 0 }}
			transition={{ delay: 0.4 }}
		>
			<h2 className='text-lg font-medium mb-4 text-gray-100'>Sales by Channel</h2>

			<div className='h-80'>
				<ResponsiveContainer>
					<BarChart data={SALES_CHANNEL_DATA}>
						<CartesianGrid strokeDasharray='3 3' stroke='#4B5563' />
						<XAxis dataKey='name' stroke='#9CA3AF' />
						<YAxis stroke='#9CA3AF' />
						<Tooltip
							contentStyle={{
								backgroundColor: "rgba(31, 41, 55, 0.8)",
								borderColor: "#4B5563",
							}}
							itemStyle={{ color: "#E5E7EB" }}
						/>
						<Legend />
						<Bar dataKey={"value"} fill='#8884d8'>
							{SALES_CHANNEL_DATA.map((entry, index) => (
								<Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
							))}
						</Bar>
					</BarChart>
				</ResponsiveContainer>
			</div>
		</motion.div>
	);
};
export default SalesChannelChart;
=======
// import { motion } from "framer-motion";
// import { BarChart, Bar, XAxis, YAxis, CartesianGrid, Tooltip, ResponsiveContainer, Legend, Cell } from "recharts";

// const COLORS = ["#6366F1", "#8B5CF6", "#EC4899", "#10B981", "#F59E0B"];

// const SALES_CHANNEL_DATA = [
// 	{ "name": "Trang web", "value": 45600 },
// { "name": "Ứng dụng di động", "value": 38200 },
// { "name": "Sàn thương mại", "value": 29800 },
// { "name": "Mạng xã hội", "value": 18700 },
// ];

// const SalesChannelChart = () => {
// 	return (
// 		<motion.div
// 			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 lg:col-span-2 border border-gray-700'
// 			initial={{ opacity: 0, y: 20 }}
// 			animate={{ opacity: 1, y: 0 }}
// 			transition={{ delay: 0.4 }}
// 		>
// 			<h2 className='text-lg font-medium mb-4 text-gray-100'>Sales by Channel</h2>

// 			<div className='h-80'>
// 				<ResponsiveContainer>
// 					<BarChart data={SALES_CHANNEL_DATA}>
// 						<CartesianGrid strokeDasharray='3 3' stroke='#4B5563' />
// 						<XAxis dataKey='name' stroke='#9CA3AF' />
// 						<YAxis stroke='#9CA3AF' />
// 						<Tooltip
// 							contentStyle={{
// 								backgroundColor: "rgba(31, 41, 55, 0.8)",
// 								borderColor: "#4B5563",
// 							}}
// 							itemStyle={{ color: "#E5E7EB" }}
// 						/>
// 						<Legend />
// 						<Bar dataKey={"value"} fill='#8884d8'>
// 							{SALES_CHANNEL_DATA.map((entry, index) => (
// 								<Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
// 							))}
// 						</Bar>
// 					</BarChart>
// 				</ResponsiveContainer>
// 			</div>
// 		</motion.div>
// 	);
// };
// export default SalesChannelChart;

import { motion } from "framer-motion";
import { useEffect, useState } from "react";
import {
  BarChart,
  Bar,
  XAxis,
  YAxis,
  CartesianGrid,
  Tooltip,
  ResponsiveContainer,
  Legend,
  Cell,
} from "recharts";

const COLORS = ["#6366F1", "#8B5CF6", "#EC4899", "#10B981", "#F59E0B"];

const SalesChannelChart = () => {
  const [salesData, setSalesData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Fetch sales data from a public API
  useEffect(() => {
    fetch("https://fakestoreapi.com/products")
      .then((response) => response.json())
      .then((data) => {
        // Simulated sales distribution from API data
        const totalSales = data.length * 100; // Example total sales
        const updatedSalesData = [
          { name: "Trang web", value: totalSales * 0.4 },
          { name: "Ứng dụng di động", value: totalSales * 0.3 },
          { name: "Sàn thương mại", value: totalSales * 0.2 },
          { name: "Mạng xã hội", value: totalSales * 0.1 },
        ];
        setSalesData(updatedSalesData);
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
      className="bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 lg:col-span-2 border border-gray-700"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ delay: 0.4 }}
    >
      <h2 className="text-lg font-medium mb-4 text-gray-100">Sales by Channel</h2>

      <div className="h-80">
        {loading ? (
          <p className="text-white text-center">Loading data...</p>
        ) : error ? (
          <p className="text-red-500 text-center">{error}</p>
        ) : (
          <ResponsiveContainer>
            <BarChart data={salesData}>
              <CartesianGrid strokeDasharray="3 3" stroke="#4B5563" />
              <XAxis dataKey="name" stroke="#9CA3AF" />
              <YAxis stroke="#9CA3AF" />
              <Tooltip
                contentStyle={{
                  backgroundColor: "rgba(31, 41, 55, 0.8)",
                  borderColor: "#4B5563",
                }}
                itemStyle={{ color: "#E5E7EB" }}
              />
              <Legend />
              <Bar dataKey={"value"} fill="#8884d8">
                {salesData.map((entry, index) => (
                  <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
              </Bar>
            </BarChart>
          </ResponsiveContainer>
        )}
      </div>
    </motion.div>
  );
};

export default SalesChannelChart;
>>>>>>> e644d97 (Adjust the Admin Pages)

<<<<<<< HEAD
import { motion } from "framer-motion";
import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer, Legend } from "recharts";

const categoryData = [
	{ "name": "Điện tử", "value": 4500 },
{ "name": "Quần áo", "value": 3200 },
{ "name": "Nhà & Vườn", "value": 2800 },
{ "name": "Sách", "value": 2100 },
{ "name": "Thể thao & Dã ngoại", "value": 1900 },

];
=======
// import { motion } from "framer-motion";
// import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer, Legend } from "recharts";

// const categoryData = [
// 	{ "name": "Điện tử", "value": 4500 },
// { "name": "Quần áo", "value": 3200 },
// { "name": "Nhà & Vườn", "value": 2800 },
// { "name": "Sách", "value": 2100 },
// { "name": "Thể thao & Dã ngoại", "value": 1900 },

// ];

// const COLORS = ["#6366F1", "#8B5CF6", "#EC4899", "#10B981", "#F59E0B"];

// const CategoryDistributionChart = () => {
// 	return (
// 		<motion.div
// 			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700'
// 			initial={{ opacity: 0, y: 20 }}
// 			animate={{ opacity: 1, y: 0 }}
// 			transition={{ delay: 0.3 }}
// 		>
// 			<h2 className='text-lg font-medium mb-4 text-gray-100'>Phân bố doanh mục</h2>
// 			<div className='h-80'>
// 				<ResponsiveContainer width={"100%"} height={"100%"}>
// 					<PieChart>
// 						<Pie
// 							data={categoryData}
// 							cx={"50%"}
// 							cy={"50%"}
// 							labelLine={false}
// 							outerRadius={80}
// 							fill='#8884d8'
// 							dataKey='value'
// 							label={({ name, percent }) => `${name} ${(percent * 100).toFixed(0)}%`}
// 						>
// 							{categoryData.map((entry, index) => (
// 								<Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
// 							))}
// 						</Pie>
// 						<Tooltip
// 							contentStyle={{
// 								backgroundColor: "rgba(31, 41, 55, 0.8)",
// 								borderColor: "#4B5563",
// 							}}
// 							itemStyle={{ color: "#E5E7EB" }}
// 						/>
// 						<Legend />
// 					</PieChart>
// 				</ResponsiveContainer>
// 			</div>
// 		</motion.div>
// 	);
// };
// export default CategoryDistributionChart;


import { motion } from "framer-motion";
import { PieChart, Pie, Cell, Tooltip, ResponsiveContainer, Legend } from "recharts";
import { useEffect, useState } from "react";
>>>>>>> e644d97 (Adjust the Admin Pages)

const COLORS = ["#6366F1", "#8B5CF6", "#EC4899", "#10B981", "#F59E0B"];

const CategoryDistributionChart = () => {
<<<<<<< HEAD
	return (
		<motion.div
			className='bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700'
			initial={{ opacity: 0, y: 20 }}
			animate={{ opacity: 1, y: 0 }}
			transition={{ delay: 0.3 }}
		>
			<h2 className='text-lg font-medium mb-4 text-gray-100'>Phân bố doanh mục</h2>
			<div className='h-80'>
				<ResponsiveContainer width={"100%"} height={"100%"}>
					<PieChart>
						<Pie
							data={categoryData}
							cx={"50%"}
							cy={"50%"}
							labelLine={false}
							outerRadius={80}
							fill='#8884d8'
							dataKey='value'
							label={({ name, percent }) => `${name} ${(percent * 100).toFixed(0)}%`}
						>
							{categoryData.map((entry, index) => (
								<Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
							))}
						</Pie>
						<Tooltip
							contentStyle={{
								backgroundColor: "rgba(31, 41, 55, 0.8)",
								borderColor: "#4B5563",
							}}
							itemStyle={{ color: "#E5E7EB" }}
						/>
						<Legend />
					</PieChart>
				</ResponsiveContainer>
			</div>
		</motion.div>
	);
};
export default CategoryDistributionChart;
=======
  const [categoryData, setCategoryData] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Fetch product categories from API
  useEffect(() => {
    fetch("https://fakestoreapi.com/products")
      .then((response) => response.json())
      .then((data) => {
        // Grouping products by category
        const categoryMap = data.reduce((acc, product) => {
          acc[product.category] = (acc[product.category] || 0) + 1;
          return acc;
        }, {});

        // Convert to chart-friendly format
        const formattedData = Object.entries(categoryMap).map(([name, value]) => ({
          name,
          value,
        }));

        setCategoryData(formattedData);
        setLoading(false);
      })
      .catch((err) => {
        console.error("Error fetching category data:", err);
        setError("Failed to load category data");
        setLoading(false);
      });
  }, []);

  return (
    <motion.div
      className="bg-gray-800 bg-opacity-50 backdrop-blur-md shadow-lg rounded-xl p-6 border border-gray-700"
      initial={{ opacity: 0, y: 20 }}
      animate={{ opacity: 1, y: 0 }}
      transition={{ delay: 0.3 }}
    >
      <h2 className="text-lg font-medium mb-4 text-gray-100">Phân Bố Danh Mục</h2>

      <div className="h-80">
        {loading ? (
          <p className="text-white text-center">Loading data...</p>
        ) : error ? (
          <p className="text-red-500 text-center">{error}</p>
        ) : (
          <ResponsiveContainer width={"100%"} height={"100%"}>
            <PieChart>
              <Pie
                data={categoryData}
                cx={"50%"}
                cy={"50%"}
                labelLine={false}
                outerRadius={80}
                fill="#8884d8"
                dataKey="value"
                label={({ name, percent }) => `${name} ${(percent * 100).toFixed(0)}%`}
              >
                {categoryData.map((entry, index) => (
                  <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} />
                ))}
              </Pie>
              <Tooltip
                contentStyle={{
                  backgroundColor: "rgba(31, 41, 55, 0.8)",
                  borderColor: "#4B5563",
                }}
                itemStyle={{ color: "#E5E7EB" }}
              />
              <Legend />
            </PieChart>
          </ResponsiveContainer>
        )}
      </div>
    </motion.div>
  );
};

export default CategoryDistributionChart;
>>>>>>> e644d97 (Adjust the Admin Pages)

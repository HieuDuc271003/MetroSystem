<<<<<<< HEAD
import { BarChart2, ShoppingBag, Users, Zap } from "lucide-react";
import { motion } from "framer-motion";
=======
// import { BarChart2, ShoppingBag, Users, Zap } from "lucide-react";
// import { motion } from "framer-motion";

// import Header from "../header_admin/Header";
// import StatCard from "../statcard/StatCard";
// import SalesOverviewChart from "../salesOverview/SalesOverviewChart";
// import CategoryDistributionChart from "../category/CategoryDistributionChart";
// import SalesChannelChart from "../salesChanel/SalesChannelChart";

// const OverviewPage = () => {
// 	return (
// 		<div className='flex-1 overflow-auto relative z-10'>
// 			<Header title='Tổng quan' />

// 			<main className='max-w-7xl mx-auto py-6 px-4 lg:px-8'>
// 				{/* STATS */}
// 				<motion.div
// 					className='grid grid-cols-1 gap-5 sm:grid-cols-2 lg:grid-cols-4 mb-8'
// 					initial={{ opacity: 0, y: 20 }}
// 					animate={{ opacity: 1, y: 0 }}
// 					transition={{ duration: 1 }}
// 				>
// 					<StatCard name='Tổng doanh số' icon={Zap} value='$12,345' color='#6366F1' />
// 					<StatCard name='Người dùng mới' icon={Users} value='1,234' color='#8B5CF6' />
// 					<StatCard name='Tổng số sản phẩm' icon={ShoppingBag} value='567' color='#EC4899' />
// 					<StatCard name='Tỷ lệ chuyển đổi' icon={BarChart2} value='12.5%' color='#10B981' />
// 				</motion.div>

// 				{/* CHARTS */}

// 				<div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
// 					<SalesOverviewChart />
// 					<CategoryDistributionChart />
// 					<SalesChannelChart />
// 				</div>
// 			</main>
// 		</div>
// 	);
// };
// export default OverviewPage;

import { BarChart2, ShoppingBag, Users, Zap } from "lucide-react";
import { motion } from "framer-motion";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom"; // ✅ Import navigation hook
>>>>>>> e644d97 (Adjust the Admin Pages)

import Header from "../header_admin/Header";
import StatCard from "../statcard/StatCard";
import SalesOverviewChart from "../salesOverview/SalesOverviewChart";
import CategoryDistributionChart from "../category/CategoryDistributionChart";
import SalesChannelChart from "../salesChanel/SalesChannelChart";

<<<<<<< HEAD
const OverviewPage = () => {
	return (
		<div className='flex-1 overflow-auto relative z-10'>
			<Header title='Tổng quan' />

			<main className='max-w-7xl mx-auto py-6 px-4 lg:px-8'>
				{/* STATS */}
				<motion.div
					className='grid grid-cols-1 gap-5 sm:grid-cols-2 lg:grid-cols-4 mb-8'
					initial={{ opacity: 0, y: 20 }}
					animate={{ opacity: 1, y: 0 }}
					transition={{ duration: 1 }}
				>
					<StatCard name='Tổng doanh số' icon={Zap} value='$12,345' color='#6366F1' />
					<StatCard name='Người dùng mới' icon={Users} value='1,234' color='#8B5CF6' />
					<StatCard name='Tổng số sản phẩm' icon={ShoppingBag} value='567' color='#EC4899' />
					<StatCard name='Tỷ lệ chuyển đổi' icon={BarChart2} value='12.5%' color='#10B981' />
				</motion.div>

				{/* CHARTS */}

				<div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
					<SalesOverviewChart />
					<CategoryDistributionChart />
					<SalesChannelChart />
				</div>
			</main>
		</div>
	);
};
export default OverviewPage;
=======

const OverviewPage = () => {
  const navigate = useNavigate(); // ✅ Create navigation function

  const [stats, setStats] = useState({
    revenue: 0,
    users: 0,
    products: 0,
    conversionRate: "0%",
  });

  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  // Fetch statistics from a public API (example)
  useEffect(() => {
	fetch("https://dummyjson.com/products")
	  .then((res) => res.json())
	  .then((data) => {
		setStats({
		  revenue: `$${(data.products.length * 100).toLocaleString()}`,
		  users: data.products.length * 5, // Example calculation
		  products: data.products.length,
		  conversionRate: `${(Math.random() * 10 + 5).toFixed(1)}%`, // Simulated data
		});
		setLoading(false);
	  })
	  .catch((err) => {
		console.error("Error fetching data:", err);
		setError("Failed to load data");
		setLoading(false);
	  });
  }, []);

  return (
    <div className="flex-1 overflow-auto relative z-10">
      {/* Page Header */}
      <Header title="Tổng quan" />

      <main className="max-w-7xl mx-auto py-6 px-4 lg:px-8">
        {/* Loading or Error State */}
        {loading && <p className="text-white text-center">Loading data...</p>}
        {error && <p className="text-red-500 text-center">{error}</p>}

        {!loading && !error && (
          <>
            {/* Statistics Cards */}
            <motion.div
              className="grid grid-cols-1 gap-5 sm:grid-cols-2 lg:grid-cols-4 mb-8"
              initial={{ opacity: 0, y: 20 }}
              animate={{ opacity: 1, y: 0 }}
              transition={{ duration: 1 }}
            >
              <StatCard name="Tổng doanh số" icon={Zap} value={stats.revenue} color="#6366F1" />
              <StatCard name="Người dùng mới" icon={Users} value={stats.users} color="#8B5CF6" />
              <StatCard name="Tổng số sản phẩm" icon={ShoppingBag} value={stats.products} color="#EC4899" />
              <StatCard name="Tỷ lệ chuyển đổi" icon={BarChart2} value={stats.conversionRate} color="#10B981" />
            </motion.div>

            {/* Charts Section */}
            <div className="grid grid-cols-1 lg:grid-cols-2 gap-8">
              <div>
                <SalesOverviewChart />
              </div>
              <div>
                <CategoryDistributionChart />
              </div>

              <div>
                <SalesChannelChart />
              </div>
            
            </div>
          </>
        )}
      </main>
    </div>
  );
};

export default OverviewPage;


>>>>>>> e644d97 (Adjust the Admin Pages)

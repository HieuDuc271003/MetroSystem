import { BarChart2, ShoppingBag, Users, Zap } from "lucide-react";
import { motion } from "framer-motion";

import Header from "../header_staff/HeaderStaff";
import StatCard from "../statcardStaff/StatCard";
import SalesOverviewChart from "../salesOverviewStaff/SalesOverviewChart";
import CategoryDistributionChart from "../categoryStaff/CategoryDistributionChartStaff";
import SalesChannelChart from "../salesChanelStaff/SalesChannelChart";

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
					<StatCard name='Tổng doanh thu' icon={Zap} value='$12,345' color='#6366F1' />
  					<StatCard name='Tổng dùng mới' icon={Users} value='1,234' color='#8B5CF6' />
					<StatCard name='Tổng chuyến xe' icon={ShoppingBag} value='567' color='#EC4899' />
					<StatCard name='Tổng các tuyến đường' icon={BarChart2} value='1293' color='#10B981' />
				</motion.div>

				{/* CHARTS */}

				{/* <div className='grid grid-cols-1 lg:grid-cols-2 gap-8'>
					<SalesOverviewChart />
					<CategoryDistributionChart />
					<SalesChannelChart />
				</div> */}
			</main>
		</div>
	);
};
export default OverviewPage;
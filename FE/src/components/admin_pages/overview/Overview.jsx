import { BarChart2, ShoppingBag, Users, Zap } from "lucide-react";
import { motion } from "framer-motion";

import Header from "../header_admin/Header";
import StatCard from "../statcard/StatCard";
import SalesOverviewChart from "../salesOverview/SalesOverviewChart";
import CategoryDistributionChart from "../category/CategoryDistributionChart";
import SalesChannelChart from "../salesChanel/SalesChannelChart";

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
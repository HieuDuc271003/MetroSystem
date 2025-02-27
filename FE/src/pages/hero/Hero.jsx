import React from 'react'
import { motion } from "framer-motion"
import Bus3 from "../../assets/bus3.png"
import Metro from "../../assets/metro.png"
import { Link } from 'react-router-dom';

export default function Hero() {
    const imageVariants = {
        initial: {
            x: "100%"
        },
        animate: {
            x: '3%',
            transition: {
                duration: 3,
                ease: 'easeInOut'
            }
        },
        exit: {
            opacity: 0,
            scale: 0
        }
    }

    return (
        <div className='w-full h-[calc(100vh-8ch)] lg:ps-28 md:ps-16 sm:ps-7 ps-4 mt-[8ch] flex items-center justify-center flex-col hero relative'>
            <div className="flex-1 w-full flex items-stretch justify-between gap-12 pb-10">
                
                {/* Nội dung bên trái */}
                <motion.div className="w-[35%] h-auto rounded-md flex justify-center flex-col space-y-14"
                    initial={{ opacity: 0, y: -10 }}
                    animate={{ opacity: 1, y: 0 }}
                    transition={{ duration: 0.5, ease: 'linear', delay: 0.2 }}
                >
                    <motion.div className="space-y-5"
                        initial={{ opacity: 0, y: -10 }}
                        animate={{ opacity: 1, y: 0 }}
                        transition={{ duration: 1, ease: 'linear', delay: 0.2 }}
                    >
                        <motion.h1 className="text-7xl font-bold text-neutral-50 leading-[1.15]"
                            initial={{ opacity: 0, y: -10 }}
                            animate={{ opacity: 1, y: 0 }}
                            transition={{ duration: 1, ease: 'linear', delay: 0.4 }}
                        >
                            Tìm đường đến
                            <span className="text-sky-400 tracking-wider"> Metro</span>
                            ngay
                        </motion.h1>
                        <motion.p className="text-lg font-normal text-neutral-300 line-clamp-3 text-ellipsis"
                            initial={{ opacity: 0, y: -10 }}
                            animate={{ opacity: 1, y: 0 }}
                            transition={{ duration: 1, ease: 'linear', delay: 0.6 }}
                        >
                           Đi Metro chưa bao giờ dễ dàng hơn . Hãy chat với chúng tôi ngay hôm nay!
                        </motion.p>
                    </motion.div>

                    <motion.button className="w-fit bg-sky-800 hover:bg-black text-neutral-50 font-medium py-3 px-6 rounded-md ease-in-out duration-300">
                        <Link to='/chatbot'>Chat để tìm đường</Link>
                    </motion.button>
                </motion.div>

                {/* Hình ảnh bên phải */}
                <div className="w-[70%] h-full rounded-md flex items-end justify-end absolute top-0 -right-48">
                    <motion.img
                        className="w-full aspect-[4/2] object-contain"
                        src={Metro}
                        alt="bus image"
                        initial="initial"
                        animate="animate"
                        variants={imageVariants}
                    />
                </div>
            </div>
        </div>
    )
}

import React from 'react'
import './chatbot.css'
import AI from '../../assets/AI.jpg'
import USER from '../../assets/user.jpg'
import { CiImageOn } from "react-icons/ci";
import { FaArrowCircleUp } from "react-icons/fa";
import buttonIMG from '../../assets/img.svg'
import buttonsSubmit from '../../assets/submit.svg'

export default function Chatbot() {
    console.log("da render")
  return (
    <div className='w-screen h-[calc(100vh-8ch)] mt-[8ch]'>
    <div className='chat-container'>
    <div className='user-chat-box'>
        <img src={USER} alt=""  id='userImage' width='50'/>
        <div className="user-chat-area">
            Hi 
        </div>
    </div>
    <div className='ai-chat-box'>
        <img src={AI} alt="" id='aiImage' width='50' />
        <div className="ai-chat-area">
            Mình có thể giúp đỡ gì?
        </div>
    </div>
    <div className='user-chat-box'>
        <img src={USER} alt=""  id='userImage' width='50'/>
        <div className="user-chat-area">
            Mình muốn đi metro
        </div>
    </div>
    <div className='ai-chat-box'>
        <img src={AI} alt="" id='aiImage' width='50' />
        <div className="ai-chat-area">
            Bạn vui lòng cho biết vị trí hiện tại
        </div>
    </div>
    <div className='user-chat-box'>
        <img src={USER} alt=""  id='userImage' width='50'/>
        <div className="user-chat-area">
            123/123/đường
        </div>
    </div>
    <div className='ai-chat-box'>
        <img src={AI} alt="" id='aiImage' width='50' />
        <div className="ai-chat-area">
           Khoảng cách của bạn quá 5km không thể đến được metro
        </div>
    </div>
    <div className='user-chat-box'>
        <img src={USER} alt=""  id='userImage' width='50'/>
        <div className="user-chat-area">
           vậy 124/124/đường
        </div>
    </div>
    <div className='ai-chat-box'>
        <img src={AI} alt="" id='aiImage' width='50' />
        <div className="ai-chat-area">
           Khoảng cách của bạn dưới 5km có thể đến được metro bạn vui lòng theo dõi các thông tin chuyến để đến metro
        </div>
    </div>
    
    </div>
    
    <div className='prompt-area'>
        <input type="text" id="prompt" placeholder="Type a message..." />
        <button id='image'><img src={buttonIMG} alt="" /></button>
        <button id="submit"><img src={buttonsSubmit} alt="" /></button>
    </div>
    </div>
  
  )
}

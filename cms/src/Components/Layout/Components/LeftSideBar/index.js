import React from 'react';
import { useState,useEffect } from 'react';
import { useLocation } from 'react-router';
import { Menu,Layout } from 'antd';
import { navbarTitle } from '../../../../CommoHelper/Constant/navbarTitle';


const LeftSideBar = ({ collapsed }) => {
  const {Sider}=Layout;
  const location=useLocation().pathname
  const [current, setCurrent] = useState(location);
  
  useEffect(()=>{
  setCurrent(location)
  },[location])
  
  
  return (
    <Sider trigger={null} style={{
      minHeight:'100vh'
    }} collapsible collapsed={collapsed}>
      <div className="demo-logo-vertical text-center"  >
        <img src='logo192.png' width="50" height="50" />
      </div>
      <Menu
        theme="dark"
        mode="inline"
        selectedKeys={current}
        defaultSelectedKeys={['1']}
        items={navbarTitle}
      />
   
    </Sider>
  );
};

export default LeftSideBar;

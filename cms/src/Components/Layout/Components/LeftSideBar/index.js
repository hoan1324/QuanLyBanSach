import React from 'react';
import { useState, useEffect, useCallback } from 'react';
import { useLocation } from 'react-router';
import { Menu, Layout } from 'antd';
import { navbarTitle } from "../../../../CommonHelper/Constant/navbarTitle"
import useResponse from '../../../../store/responseStore';
import usePageStore from '../../../../store/pageStore';

const LeftSideBar = ({ collapsed }) => {
  const { Sider } = Layout;
  const location = useLocation().pathname
  const [current, setCurrent] = useState(location);
  const { resetElementConvert } = useResponse();
  const { resetElementPage } = usePageStore()
  const resetConvert = useCallback(() => {
    resetElementConvert();
    resetElementPage();
  }, [resetElementConvert, resetElementPage]);

  useEffect(() => {
    resetConvert();
    setCurrent(location);
  }, [location, resetConvert]); // ✅ Chỉ phụ thuộc vào `location` và `resetConvert`


  return (
    <Sider trigger={null} style={{
      minHeight: '100vh'
    }} collapsible collapsed={collapsed}>
      <div className="demo-logo-vertical text-center"  >
        <img src='logo192.png' width="50" height="50" alt='Logo' />
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

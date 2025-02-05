import React, { useState } from 'react';
import { Layout, theme, message } from 'antd';
import LeftSideBar from '../Components/LeftSideBar';
import HeaderBar from '../Components/HeaderBar';

const { Content } = Layout;

const DefaultLayout = ({ children }) => {
  const [collapsed, setCollapsed] = useState(false);
  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();
  const [contextHolder] = message.useMessage();
  return (
    <Layout >
      <LeftSideBar collapsed={collapsed} />
      <Layout>
        <HeaderBar
          collapsed={collapsed}
          setCollapsed={setCollapsed}
          backgroundColor={colorBgContainer}
        />
        <Content
          style={{
            margin: '24px 16px',
            padding: 24,
            minHeight: 280,
            background: colorBgContainer,
            borderRadius: borderRadiusLG,
          }}
        >
          {children}
        </Content>
      </Layout>
    </Layout>
  );
};

export default DefaultLayout;

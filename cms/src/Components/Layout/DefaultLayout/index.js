import React, { useState, useEffect } from 'react';
import { Layout, theme } from 'antd';
import LeftSideBar from '../Components/LeftSideBar';
import HeaderBar from '../Components/HeaderBar';
import services from '../../../boot/services';
import useAuthStore from '../../../store/authStore';
import { actionDiffirent } from '../../../CommonHelper/utils/helper/communicateApi';
const { Content } = Layout;

const DefaultLayout = ({ children }) => {
  const [collapsed, setCollapsed] = useState(false);

  const {
    token: { colorBgContainer, borderRadiusLG },
  } = theme.useToken();
  const getCurrentUser = useAuthStore((state) => state.getCurrentUser);
  const setCurrentUser = useAuthStore((state) => state.setCurrentUser);

  useEffect(() => {
    const dispatchCurrentUser = async () => {
      if (getCurrentUser()?.id) {
        return;
      }

      try {
        const response = await actionDiffirent(services.authService, "getCurrentUser", []);
        console.log(response);

        if (response.isSuccess) {
          setCurrentUser(response.data);

        }
      } catch (error) {
        console.log(error);
      }
    };

    dispatchCurrentUser();
  }, [getCurrentUser, setCurrentUser]); // Chỉ phụ thuộc vào các state cần thiết
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

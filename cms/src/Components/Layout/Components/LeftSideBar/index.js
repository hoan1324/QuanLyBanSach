import { useState, useEffect, useCallback } from "react";
import { useLocation } from "react-router";
import { Menu, Layout } from "antd";
import { navbarTitle } from "../../../../CommonHelper/Constant/navbarTitle";
import usePageStore from "../../../../store/pageStore";
import useAuthStore from "../../../../store/authStore";
import { filterMenuByPermission } from "../../../../CommonHelper/utils/helper/menuHelper";

const LeftSideBar = ({ collapsed }) => {
  const { Sider } = Layout;
  const location = useLocation().pathname;
  const [current, setCurrent] = useState(location);
  const { resetElementPage } = usePageStore();
  const { getCurrentUser } = useAuthStore();

  const resetConvert = useCallback(() => {
    resetElementPage();
  }, [resetElementPage]);

  useEffect(() => {
    resetConvert();
    setCurrent(location);
  }, [location, resetConvert]); // ✅ Chỉ phụ thuộc vào `location` và `resetConvert`

  return (
    <Sider
      trigger={null}
      style={{
        minHeight: "100vh",
      }}
      collapsible
      collapsed={collapsed}
    >
      <div className="demo-logo-vertical text-center">
        <img src="logo192.png" width="50" height="50" alt="Logo" />
      </div>
      <Menu
        theme="dark"
        mode="inline"
        selectedKeys={current}
        defaultSelectedKeys={["1"]}
        items={filterMenuByPermission(
          navbarTitle,
          getCurrentUser()?.isAdmin,
          getCurrentUser()?.userPermissions
        )}
      />
    </Sider>
  );
};

export default LeftSideBar;

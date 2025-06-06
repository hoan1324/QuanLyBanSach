import { Button, Dropdown, Image } from "antd";
import { MenuFoldOutlined, MenuUnfoldOutlined } from "@ant-design/icons";
import itemDropDownUser from "../../../../CommonHelper/Constant/itemDropdownUser";
import useAuthStore from "../../../../store/authStore";
import { urlApi } from "../../../../CommonHelper/utils/helper/urlApiFile";
import { useNavigate } from "react-router-dom";
import constantType from "../../../../CommonHelper/Constant/constantType";

const HeaderBar = ({ collapsed, setCollapsed, backgroundColor }) => {
  const { getCurrentUser, logOut } = useAuthStore();
  const navigate = useNavigate();

  const handleMenuClick = ({ key }) => {
    switch (key) {
      case constantType.keyDropDown.setting:
        navigate("/settings");
        break;
      case constantType.keyDropDown.logout:
        logOut();
        navigate("/");
        break;
      default:
        break;
    }
  };
  return (
    <div
      style={{
        padding: 0,
        background: backgroundColor,
        display: "flex",
        alignItems: "center",
        justifyContent: "space-between",
      }}
    >
      <Button
        type="text"
        icon={collapsed ? <MenuUnfoldOutlined /> : <MenuFoldOutlined />}
        onClick={() => setCollapsed(!collapsed)}
        style={{
          fontSize: "16px",
          width: 64,
          height: 64,
        }}
      />
      <Dropdown
        arrow={false}
        menu={{
          items: itemDropDownUser(
            `Xin chào ${
              getCurrentUser()?.userName?.length > 6
                ? getCurrentUser().userName.substring(0, 6) + "..."
                : getCurrentUser().userName
            }`
          ),
          onClick: handleMenuClick,
        }}
        trigger={["click"]}
      >
        <div className="d-flex align-items-center justify-content-between me-3">
          <img
            src={
              getCurrentUser()?.avatar
                ? urlApi(getCurrentUser.avatar)
                : "/default-avatar.png"
            }
            alt="Avatar"
            width={40}
            height={40}
            style={{
              borderRadius: "50%",
              cursor: "pointer",
              objectFit: "cover",
              border: "1px solid #ccc",
              marginRight: "8px",
            }}
          />
        </div>
        {/* <a onClick={(e) => e.preventDefault()}>
          <Space>
            Hover me
            <DownOutlined />
          </Space>
        </a> */}
      </Dropdown>
    </div>
  );
};

export default HeaderBar;

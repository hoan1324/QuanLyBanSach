import { DownOutlined, SettingOutlined } from "@ant-design/icons";
import { CiLogout } from "react-icons/ci";
import constantType from "./constantType";

const itemDropDownUser = (useName) => [
  {
    key: constantType.keyDropDown.myAccount,
    label: useName,
    disabled: true,
    align: "center",
  },
  {
    type: "divider",
  },

  {
    key: constantType.keyDropDown.setting,
    label: "Cài đặt",
    icon: <SettingOutlined />,
  },
  {
    key: constantType.keyDropDown.logout,
    label: "Đăng xuất",
    icon: <CiLogout />,
  },
];
export default itemDropDownUser;

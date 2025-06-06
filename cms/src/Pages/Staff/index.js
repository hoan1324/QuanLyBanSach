import staffColumn from "../../Components/TableColumn/staffColumn";
import services from "../../boot/services";
import { Form } from "antd";

import {
  convertDates,
  convertDayjsToString,
} from "../../CommonHelper/utils/helper/dateHelper";

import constantType from "../../CommonHelper/Constant/constantType";
import TemplatePage from "../../Components/Common/templatePage";
import StaffForm from "./StaffForm";
import StaffDetail from "./StaffDetail";
import { useState } from "react";
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";

// Chuyển đổi dữ liệu API thành định dạng phù hợp cho bảng

function Staff() {
  // Hàm lấy dữ liệu nhân viên từ API
  const [fileSelect, setFileSelect] = useState(null);
  const [form] = Form.useForm();

  const urlActionAsisign = (staff) => {
    setFileSelect(staff?.avatar);
    form.setFieldValue("avatar", fileSelect);
  };

  return (
    <TemplatePage
      ModalForm={() => (
        <StaffForm
          form={form}
          fileSelect={fileSelect}
          setFileSelect={setFileSelect}
        />
      )}
      ModalDetail={StaffDetail}
      config={{
        ...config,
        form: form,
        transferResponse: convertDates,
        transferRequest: convertDayjsToString,
        urlActionAsisign: urlActionAsisign,
      }}
    ></TemplatePage>
  );
}
const dataSource = (data) => {
  return data.map((element, index) => ({
    stt: index + 1,
    key: element.id,
    name: element.name,
    dateOfBirth: element.dateOfBirth,
    address: element.address,
    phoneNumber: element.phoneNumber,
    email: element.email,
    startDate: element.startDate,
    gender: element.gender,
    status: element.status,
  }));
};
const config = {
  title: "Quản lý nhân viên",
  modalName: "nhân viên",
  service: services.staffService,
  dataSource: dataSource,
  column: staffColumn,
  permissionController: "Staff",
  filters: [
    {
      filterFields: ["Name", "PhoneNumber", "Email"],
      value: null,
      condition: constantType.filterCondition.contain,
      filterType: constantType.filterType.textBox,
      title: "Tìm kiếm tên ,số điện thoại ,email,...",
    },
    {
      filterFields: ["Status"],
      value: null,
      condition: constantType.filterCondition.equal,
      filterType: constantType.filterType.selectBox,
      title: "Tìm kiếm trạng thái công việc,...",
      options: UseStatusMixin().staffStatus,
    },
    {
      filterFields: ["StartDate"],
      value: null,
      condition: constantType.filterCondition.greaterThanOrEqual,
      filterType: constantType.filterType.rangeDatePicker,
      title: "Tìm kiếm ngày bắt đâu,...",
    },
  ],
};
export default Staff;

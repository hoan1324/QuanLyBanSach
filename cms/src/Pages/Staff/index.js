// import { Table, Pagination, Button, Form, InputNumber, Divider, Input, message, Tag } from "antd";
// import { DatePicker, Select } from 'antd';
// import { IoIosAddCircleOutline } from "react-icons/io";
// import { useForm } from "antd/es/form/Form";
// import { useEffect, useState, useCallback, useRef } from "react";
// import staffColumn from "../../Components/TableColumn/staffColumn";
// import InputModal from "../../Components/Common/inputModal";
// import TextArea from "antd/es/input/TextArea";
// import services from "../../boot/services";
// import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
// import Editor from "../../boot/ckEditor"
// import { getListDropdown, getList, actionAsync, deleteAsync, findByID } from "../../CommonHelper/utils/helper/communicateApi";
// import { convertDates, convertDayjsToString } from "../../CommonHelper/utils/helper/dateHelper";
// import vnConst from "../../i18vn/vi-VN";
// import dayjs from "dayjs";
// import { formatMoneyVn } from "../../CommonHelper/utils/helper/moneyHelper";
// import FileManager from "../../Components/FileManager/fileManager";
// import TemplateExtension from "../../Components/Common/templateExtension";
// import { styleTemplate } from "../../Components/GlobalStyle/Style.js/commonStyle";
// import { urlApi } from "../../CommonHelper/utils/helper/urlApiFile";
// import { styleTag } from "../../Components/GlobalStyle/Style.js/commonStyle";
// import constantType from "../../CommonHelper/Constant/constantType";
// import TemplatePage from "../../Components/Common/templatePage";

// // Chuyển đổi dữ liệu API thành định dạng phù hợp cho bảng


// function Staff() {
//   const service = services.staffService; // Lấy staffService từ context

//   const [filter, setFilter] = useState({
//     pageIndex: 1,
//     pageSize: 20,
//     orderByColumn: "CreatedDate" || null,

//   });
//   const [fileSelect, setFileSelect] = useState()
//   const selectJob = useRef(null)
//   const [jobData, setJobData] = useState([])
//   const [title, setTitle] = useState();
//   const [open, setOpen] = useState(false);
//   const [StaffData, setStaffData] = useState({})
//   const [disabled, setDisabled] = useState(false)
//   const [form] = useForm();




//   // Hàm lấy dữ liệu nhân viên từ API
//   const fetchData = useCallback(async () => {

//     const { data, total } = await getList(service, filter);

//     setData(data);
//     setTotal(total);
//   }, [filter, service]);
//   const fetchJobData = async () => {
//     const job = await getListDropdown(services.jobService);
//     setJobData(job)


//   };
//   const handleSelect = (_, value) => {
//     console.log("Vaf Handleselect");
//     console.log(value);


//   }
//   const handleOpenModel = (title) => {
//     if (!open) {
//       setTitle(title)
//       setOpen(true)
//     }
//   }
//   const handleClose = () => {
//     if (open) {
//       form.resetFields()
//       setStaffData({})
//       setFileSelect(undefined)
//       setOpen(false)
//       if (disabled) {
//         setDisabled(false)
//       }
//     }
//   }

//   const validateEndDate = (_, value) => {

//     const valueStatus = form.getFieldValue("status");
//     const { staffStatus } = UseStatusMixin(); // Giả sử bạn có hàm này trả về status

//     var search = staffStatus.find(item => item.id === valueStatus);
//     if (search !== null) {
//       if (search.name === vnConst.currentlyEmployed) {
//         form.setFieldsValue({ endDate: null });
//       }
//       if (search.name === vnConst.resigned) {
//         if (!form.getFieldValue("endDate")) {
//           form.setFieldsValue({ endDate: dayjs() });
//         }
//       }
//     }

//     return Promise.resolve();
//   };
//   //
//   // Xử lý sự kiện khi thay đổi trang
//   const handlePageChange = (page) => {
//     setFilter(prevFilter => ({
//       ...prevFilter,
//       pageIndex: page
//     }));
//   };
//   const handleSubmit = async () => {
//     try {
//       await form.validateFields(); // Validate tất cả các trường trước khi submit
//       form.submit(); // Submit form nếu validate thành công
//     } catch (error) {
//       console.log('Vui lòng kiểm tra các trường hợp lỗi!');
//     }
//   };

//   const onFinish = async (values) => {

//     try {

//       const response = await actionAsync(service, convertDayjsToString(values));

//       if (response.isSuccess) {

//         message.success(response.messsage)

//         fetchData(); // Làm mới dữ liệu
//       } else {
//         message.error(response?.messsage)

//       }
//     } catch (error) {
//       console.log(error);

//       message.error("Có lỗi xảy ra khi xử lý dữ liệu")

//     } finally {
//       handleClose();
//     }
//   }
//   const handleEdit = async (id) => {
//     const response = await findByID(service, id);
//     setStaffData(response);
//     form.setFieldsValue(convertDates(response));
//     handleOpenModel("Chỉnh sửa nhân viên")

//   }
//   const handleDetail = async (id) => {
//     const response = await findByID(service, id);
//     setDisabled(true)
//     setStaffData(response);
//     form.setFieldsValue(convertDates(response))
//     handleOpenModel("Thông tin nhân viên")
//   }
//   const handleDelete = async (id) => {
//     try {
//       const response = await deleteAsync(service, id);
//       if (response?.isSuccess) {
//         message.success(response?.messsage)

//         fetchData(); // Làm mới dữ liệu
//       } else {
//         message.error(response?.messsage)

//       }
//     } catch (error) {
//       message.error("Có lỗi xảy ra khi xử lý dữ liệu")

//     }
//   }



//   const validateSalary = (_, value) => {

//     const valueSelect = form.getFieldValue("jobID");
//     if (!valueSelect) return Promise.reject("Vui lòng chọn công việc");

//     const selectJob = jobData?.find(item => item.id === valueSelect);
//     if (!selectJob) return Promise.reject("Công việc không hợp lệ");

//     const { salaryMin, salaryMax } = selectJob;

//     if ((salaryMin !== null && value < salaryMin) || (salaryMax !== null && value > salaryMax)) {
//       return Promise.reject(`Lương phải từ ${formatMoneyVn(salaryMin)}
//         đến ${salaryMax ? formatMoneyVn(salaryMax) : "vô cùng"}`);
//     }

//     return Promise.resolve();
//   };


//   const handleChoose = (fileSelect) => {
//     if (!constantType.extension.imageTypes.includes(fileSelect.match(/(\.[0-9a-z]+)$/i)?.[1] || "")) {
//       message.error("File không phải là ảnh");
//       return
//     }
//     setFileSelect(fileSelect)
//     form.setFieldValue('avatar', fileSelect)
//   }

//   return (
//     <TemplatePage config={config}>
//       <Form.Item name="avatar"  >
//         <Input disabled />
//       </Form.Item>
//       {fileSelect === undefined ? <FileManager className="mt-3" handleChoose={handleChoose} /> :
//         <div className="position-relative p-2 border mb-3 mt-3" style={{ width: 150 }}>
//           <Tag color="red" onClick={() => setFileSelect(undefined)} style={styleTag}>X</Tag>
//           <TemplateExtension style={styleTemplate} url={urlApi(fileSelect)} extension={fileSelect.match(/(\.[0-9a-z]+)$/i)?.[1] || ""} />
//         </div>
//       }

//       <Form.Item label="Tên nhân viên" name="name" rules={[{ required: true, message: "Vui lòng nhập tên nhân viên" }]}>
//         <Input placeholder="Nhập tên nhân viên" className="w-100"></Input>
//       </Form.Item>
//       <div className="row">
//         <div className="col-md-4">
//           <Form.Item label="Ngày sinh" name="dateOfBirth" rules={[{ required: true, message: "Vui lòng nhập ngày sinh" }]}>
//             <DatePicker format='DD/MM/YYYY' className="w-100" />
//           </Form.Item>
//         </div>
//         <div className="col-md-4">
//           <Form.Item label="Ngày bắt đầu làm việc" name="startDate" rules={[{ required: true, message: "Vui lòng nhập ngày bắt đầu" }]}>
//             <DatePicker format='DD/MM/YYYY' className="w-100" />
//           </Form.Item>
//         </div>
//         <div className="col-md-4">
//           <Form.Item dependencies={['status']} rules={[{ validator: validateEndDate }]} label="Ngày kết thúc làm việc" name="endDate">
//             <DatePicker format='DD/MM/YYYY' className="w-100" />
//           </Form.Item>
//         </div>
//       </div>
//       <div className="row">
//         <div className="col-md-6">
//           <Form.Item label="Số điện thoại" name="phoneNumber"
//             rules={[
//               { required: true, message: 'Vui lòng nhập số điện thoại' }, { pattern: /^[0-9]+$/, message: 'Số điện thoại phải là số' }]}>
//             <Input placeholder="Nhập số điện thoại" style={{ width: '100%' }} min={0} />
//           </Form.Item>
//         </div>
//         <div className="col-md-6">
//           <Form.Item label="Email" name="email"
//             rules={[
//               { required: true, message: 'Vui lòng nhập email' },
//               { type: 'email', message: "Địa chỉ phải là email " }]}>
//             <Input placeholder="Nhập email" style={{ width: '100%' }} min={0} />
//           </Form.Item>
//         </div>
//       </div>
//       <div className="row">
//         <div className="col-md-6">
//           <Form.Item label="Giới tính" name="gender" rules={[{ required: true, message: "Vui lòng chọn giới tính" }]}>
//             <Select className="w-100" options={UseStatusMixin().gender.map((element, index) => (
//               { value: element.id, label: element.name }
//             ))} />
//           </Form.Item>
//         </div>
//         <div className="col-md-6">
//           <Form.Item label="Trạng thái" name="status" rules={[{ required: true, message: "Vui lòng chọn trạng thái" }]}>
//             <Select className="w-100" options={UseStatusMixin().staffStatus.map((element, index) => (
//               { value: element.id, label: element.name }
//             ))} />
//           </Form.Item>
//         </div>
//       </div>
//       <div className="row">
//         <div className="col-md-6">
//           <Form.Item dependencies={['jobID']} label="Lương nhân viên" name="salary" rules={[{ required: true, message: "Vui lòng chọn lương nhân viên" }, { validator: validateSalary }]}>
//             <InputNumber placeholder="Nhập  lương nhân viên" style={{ width: '100%' }} min={0} />
//           </Form.Item>
//         </div>
//         <div className="col-md-6">
//           <Form.Item label="Công việc" name="jobID" rules={[{ required: true, message: "Vui lòng chọn vị trí nhân viên" }]}>
//             <Select className="w-100" key={StaffData} onSelect={handleSelect} ref={selectJob} options={jobData ? jobData.map((element, index) => (
//               { value: element.id, label: element.name, salaryMax: element.salaryMax, salaryMin: element.salaryMin }
//             )) : {}} />
//           </Form.Item>
//         </div>
//       </div>
//       <Form.Item label="Địa chỉ" name="address" rules={[{ required: true, message: "Vui lòng nhập địa chỉ" }]} >
//         <TextArea placeholder="Nhập địa chỉ"
//           autoSize={{
//             minRows: 2,
//             maxRows: 4,
//           }}></TextArea>
//       </Form.Item>
//       <Form.Item label="Tiểu sử nhân viên" name="biography" >
//         <Editor data={StaffData.biography ?? ""}
//           onChange={(event, editor) => {
//             const data = editor.getData();
//             form.setFieldsValue({ biography: data }); // Cập nhật vào form
//           }}
//         />
//       </Form.Item>
//     </TemplatePage>

//   );
// }
// const dataSource = (data) => {
//   return data.map((element, index) => ({
//     stt: index + 1,
//     key: element.id,
//     name: element.name,
//     dateOfBirth: element.dateOfBirth,
//     salary: element.salary,
//     address: element.address,
//     phoneNumber: element.phoneNumber,
//     email: element.email,
//     startDate: element.startDate,
//     endDate: element.endDate,
//     gender: element.gender,
//     avatar: element.avatar,
//     status: element.status,
//     job: element.jobID // Có thể thêm trường công việc (job) nếu cần
//   }));
// };
// const config = {
//   title: "Quản lý nhân viên",
//   modalName: "nhân viên",
//   service: services.jobService,
//   dataSource: dataSource,
//   column: staffColumn,
//   filters: [
//     {
//       filterFields: ["Name", "Description"],
//       value: null,
//       condition: constantType.filterCondition.contain,
//       filterType: constantType.filterType.textBox,
//       title: "Tìm kiếm tên ,mô tả nhân viên..."
//     }
//   ]
// }
// export default Staff;
function Staff() {
  return (
    <div>Nhan vien</div>
  )
}
export default Staff
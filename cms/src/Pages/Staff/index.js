import { Table, Pagination, Button, Form, InputNumber, Divider, Input, message, Flex, Space } from "antd";
import { DatePicker, Select } from 'antd';

import { IoIosAddCircleOutline } from "react-icons/io";
import { SearchOutlined } from '@ant-design/icons';
import { useForm } from "antd/es/form/Form";
import { useContext, useEffect, useState, useCallback, useRef } from "react";
import { columnNameStaff } from "../../CommonHelper/Constant/columnName";
import InputModal from "../../Components/Common/inputModal";
import TextArea from "antd/es/input/TextArea";
import services from "../../boot/services";
import UseStatusMixin from "../../CommonHelper/utils/mixins/status";
import _default from "antd/es/affix/style";
import Editor from "../../boot/ckEditor"
import { convertDates, convertDayjsToString } from "../../CommonHelper/utils/helper/dateHelper";
import vnConst from "../../i18vn/vi-VN";
import dayjs from "dayjs";
// Chuyển đổi dữ liệu API thành định dạng phù hợp cho bảng
const dataSource = (data) => {
  return data.map((element) => ({
    key: element.id,
    staffName: element.staffName,
    dateOfBirth: element.dateOfBirth,
    salary: element.salary,
    address: element.address,
    phoneNumber: element.phoneNumber,
    email: element.email,
    startDate: element.startDate,
    endDate: element.endDate,
    gender: element.gender,
    avatar: element.avatar,
    status: element.status,
    job: element.jobID // Có thể thêm trường công việc (job) nếu cần
  }));
};

const fetchJobsData = async (jobService) => {
  try {
    const StaffsResponse = await jobService.getListDropdown()

    if (StaffsResponse.isSuccess) {
      return StaffsResponse.data;
    }
    return [];
  } catch (error) {
    console.error("Lỗi trong fetchStaffsData:", error);
    return [];
  }
};// Hàm lấy danh sách nhân viên và tổng số nhân viên
const fetchStaffsData = async (staffService, filter) => {
  try {
    const StaffsResponse = await staffService.getList(filter)


    if (StaffsResponse.isSuccess) {
      return { Staffs: StaffsResponse.data.data, total: StaffsResponse.data.totalRow };
    }
    return { Staffs: [], total: 0 };
  } catch (error) {
    console.error("Lỗi trong fetchStaffsData:", error);
    return { Staffs: [], total: 0 };
  }
};
const actionStaffData = async (staffService, StaffData) => {
  console.log("Bắt đầy vào service");

  console.log(staffService);

  try {
    let response;
    if (StaffData.id === undefined) {
      response = await staffService.create(StaffData)
    }
    else {
      response = await staffService.update(StaffData.id, StaffData)
    }
    if (response.status === 500) {
      return { isSuccess: false, message: response.message };
    }
    return response
  }
  catch (error) {
    console.log("lỗi vào đây");
    console.log(error);

    return {
      isSuccess: false,
      message: "Có lỗi xảy ra trong quá trình xử lý.",
    };
  }
}
const deleteStaffData = async (staffService, id) => {
  try {
    const response = await staffService.delete(id)
    if (response.status === 500) {
      return { isSuccess: false, message: response.message };
    }
    return response
  }
  catch (error) {
    console.log("lỗi vào đây");
    return {
      isSuccess: false,
      message: "Có lỗi xảy ra trong quá trình xử lý.",
    };
  }
}
const findStaff = async (staffService, id) => {
  try {
    const response = await staffService.getById(id)
    if (response.status === 500 || !response.isSuccess) {
      return null;
    }
    return response.data;
  }
  catch (error) {
    console.log(error);
    return null

  }
}
function Staff() {
  const service = services.staffService; // Lấy staffService từ context
  const [data, setData] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [total, setTotal] = useState(1); // Tổng số nhân viên
  const [filter, setFilter] = useState({
    pageIndex: 1,
    pageSize: 20,
    orderByColumn: "CreatedDate" || null,

  });
  const selectJob = useRef(null)
  const [jobData, setJobData] = useState([])
  const [title, setTitle] = useState();
  const [open, setOpen] = useState(false);
  const [StaffData, setStaffData] = useState({})
  const [disabled, setDisabled] = useState(false)
  const [form] = useForm();
  const [formSearch] = useForm()

  const [messageApi, contextHolder] = message.useMessage();
  const [configFilter, setConfigFilter] = useState(
    [
      {
        filterFields: ["StaffName", "Email"],
        value: null,
        condition: "contain",
        filterType: "textbox",
        title: "Tìm kiếm"
      }
    ]
  )

  // Hàm lấy dữ liệu nhân viên từ API
  const fetchData = useCallback(async () => {

    const { Staffs, total } = await fetchStaffsData(service, filter);
    console.log(Staffs);

    setData(Staffs);
    setTotal(total);
  }, [filter, service]);
  const fetchJobData = async () => {
    const job = await fetchJobsData(services.jobService);
    console.log(jobData);
    setJobData(job)
    console.log("vào job data");


  };
  const handleSelect = (_, value) => {
    console.log("Vaf Handleselect");
    console.log(value);


  }
  const handleOpenModel = (title) => {
    if (!open) {
      {
        setTitle(title)
        setOpen(true)
      }
    }
  }
  const handleClose = () => {
    if (open) {
      {
        form.resetFields()
        setStaffData({})
        setOpen(false)
        if (disabled) {
          setDisabled(false)
        }

      }
    }
  }
  // Lắng nghe thay đổi filter (khi thay đổi trang)
  useEffect(() => {
    fetchData();
    fetchJobData()

  }, [filter]); // Chạy lại khi filter thay đổi
  const validateEndDate = (_, value) => {
    console.log("vào validate EndDate");
  
    const valueStatus = form.getFieldValue("status");
    const { staffStatus } = UseStatusMixin(); // Giả sử bạn có hàm này trả về status
  
    var search = staffStatus.find(item => item.id === valueStatus);
    if (search !== null) {
      if (search.name === vnConst.currentlyEmployed) {
        form.setFieldsValue({ endDate: null });
      }
      if (search.name === vnConst.resigned) {
        if (!form.getFieldValue("endDate")) {
          form.setFieldsValue({ endDate: dayjs() });
        }
      }
    }
    
    return Promise.resolve();
  };
 //
  // Xử lý sự kiện khi thay đổi trang
  const handlePageChange = (page) => {
    setFilter(prevFilter => ({
      ...prevFilter,
      pageIndex: page
    }));
  };
  const handleSubmit = async () => {
    try {
      await form.validateFields(); // Validate tất cả các trường trước khi submit
      form.submit(); // Submit form nếu validate thành công
    } catch (error) {
      console.log('Vui lòng kiểm tra các trường hợp lỗi!');
    }
  };

  const onFinish = async (values) => {
    console.log(convertDayjsToString(values));

    try {
      console.log("tạo create");

      const response = await actionStaffData(service, convertDayjsToString(values));
      console.log(response.messsage);

      if (response.isSuccess) {

        messageApi.open({
          type: 'success',
          content: response.messsage,
        });
        fetchData(); // Làm mới dữ liệu
      } else {
        messageApi.open({
          type: 'error',
          content: response.messsage,
        });
      }
    } catch (error) {
      messageApi.open({
        type: 'error',
        content: "Có lỗi xảy ra khi xử lý dữ liệu",
      });
    } finally {
      handleClose();
    }
  }
  const handleEdit = async (id) => {
    const response = await findStaff(service, id);
    setStaffData(response);
    form.setFieldsValue(convertDates(response));
    handleOpenModel("Chỉnh sửa nhân viên")

  }
  const handleDetail = async (id) => {
    const response = await findStaff(service, id);
    setDisabled(true)
    setStaffData(response);
    form.setFieldsValue(convertDates(response))
    handleOpenModel("Thông tin nhân viên")
  }
  const handleDelete = async (id) => {
    try {
      const response = await deleteStaffData(service, id);
      console.log(response.messsage);

      if (response.isSuccess) {

        messageApi.open({
          type: 'success',
          content: response.messsage,
        });
        fetchData(); // Làm mới dữ liệu
      } else {
        messageApi.open({
          type: 'error',
          content: response.messsage,
        });
      }
    } catch (error) {
      messageApi.open({
        type: 'error',
        content: "Có lỗi xảy ra khi xử lý dữ liệu",
      });
    }
  }
  const onFinishSearch = (values) => {
    var jsonConvert = JSON.stringify(assinValue(values))
    setFilter(pre => {
      return {
        ...pre,
        filters: jsonConvert
      }
    })
    formSearch.resetFields()
  }
  const assinValue = (values) => {
    const filter = configFilter.map((element, index) => (
      {
        filterFields: element.filterFields,
        value: values[element.filterFields.join(",")],
        condition: element.condition,
        filterType: element.filterType
      }
    ))
    return filter
  }

  const validateSalary = (_, value) => {
    console.log("Vào calidate");

    const valueSelect = form.getFieldValue("jobID");
    if (!valueSelect) return Promise.reject("Vui lòng chọn công việc");

    const selectJob = jobData?.find(item => item.id == valueSelect);
    if (!selectJob) return Promise.reject("Công việc không hợp lệ");
    console.log(selectJob);

    const { salaryMin, salaryMax } = selectJob;

    if ((salaryMin != null && value < salaryMin) || (salaryMax != null && value > salaryMax)) {
      return Promise.reject(`Lương phải từ ${salaryMin.toLocaleString("vi-VN", { style: "currency", currency: "VND" })} 
        đến ${salaryMax?.toLocaleString("vi-VN", { style: "currency", currency: "VND" }) || "vô cùng"}`);
    }

    return Promise.resolve();
  };

  return (
    <div>

      <div className="d-flex justify-content-end mb-3">
        <Button size="large" onClick={(e) => handleOpenModel('Tạo mới nhân viên')} icon={<IoIosAddCircleOutline />} type="primary">
          Thêm mới
        </Button>
      </div>
      <div className="mb-3">
        {/* <Form form={formSearch} onFinish={onFinishSearch}>
          <Flex gap="small" justify="end" align="center" wrap>
            {configFilter.map((element, index) => (
              <Form.Item key={index} className="mb-0" name={element.filterFields.join(",")} rules={[
                {
                  required: true,
                  message: 'Nhập dữ liệu',
                },
              ]} >
                <Input size="large" placeholder={element.title} />
              </Form.Item>
            ))}
            <Tooltip title="Tìm kiếm">
              <Button size="large" shape="circle" htmlType="submit" icon={<SearchOutlined />} />
            </Tooltip>
          </Flex>
        </Form> */}
      </div>
      <Table dataSource={dataSource(data)} rowKey="key" scroll={{ x: 'max-content', }} pagination={false} bordered columns={columnNameStaff({ handleEdit, handleDelete, handleDetail })} />
      <Pagination className="mt-4" align="center" onChange={handlePageChange} current={filter.pageIndex} defaultCurrent={1} pageSize={filter.pageSize} total={total} />
      <InputModal diasbled={disabled} title={title} handleOk={handleSubmit} handleClose={handleClose} width={1000} isOpen={open}>
        <Divider />
        <Form disabled={disabled} form={form} onFinish={onFinish} name="StaffForm" layout="vertical">
          <Form.Item name="id" hidden value={StaffData.id}>
            <Input disabled />
          </Form.Item>
          <Form.Item label="Tên nhân viên" name="staffName" rules={[{ required: true, message: "Vui lòng nhập tên nhân viên" }]}>
            <Input placeholder="Nhập tên nhân viên" className="w-100"></Input>
          </Form.Item>
          <div className="row">
            <div className="col-md-4">
              <Form.Item label="Ngày sinh" name="dateOfBirth" rules={[{ required: true, message: "Vui lòng nhập ngày sinh" }]}>
                <DatePicker format='DD/MM/YYYY' className="w-100" />
              </Form.Item>
            </div>
            <div className="col-md-4">
              <Form.Item label="Ngày bắt đầu làm việc" name="startDate" rules={[{ required: true, message: "Vui lòng nhập ngày bắt đầu" }]}>
                <DatePicker format='DD/MM/YYYY' className="w-100" />
              </Form.Item>
            </div>
            <div className="col-md-4">
              <Form.Item dependencies={['status']} rules={[{validator:validateEndDate}]} label="Ngày kết thúc làm việc" name="endDate">
                <DatePicker format='DD/MM/YYYY' className="w-100" />
              </Form.Item>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <Form.Item label="Số điện thoại" name="phoneNumber"
                rules={[
                  { required: true, message: 'Vui lòng nhập số điện thoại' },]}>
                <InputNumber placeholder="Nhập số điện thoại" style={{ width: '100%' }} min={0} />
              </Form.Item>
            </div>
            <div className="col-md-6">
              <Form.Item label="Email" name="email"
                rules={[
                  { required: true, message: 'Vui lòng nhập email' },
                  { type: 'email', message: "Địa chỉ phải là email " }]}>
                <Input placeholder="Nhập email" style={{ width: '100%' }} min={0} />
              </Form.Item>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <Form.Item label="Giới tính" name="gender" rules={[{ required: true, message: "Vui lòng chọn giới tính" }]}>
                <Select className="w-100" options={UseStatusMixin().gender.map((element, index) => (
                  { value: element.id, label: element.name }
                ))} />
              </Form.Item>
            </div>
            <div className="col-md-6">
              <Form.Item label="Trạng thái" name="status" rules={[{ required: true, message: "Vui lòng chọn trạng thái" }]}>
                <Select className="w-100" options={UseStatusMixin().staffStatus.map((element, index) => (
                  { value: element.id, label: element.name }
                ))} />
              </Form.Item>
            </div>
          </div>
          <div className="row">
            <div className="col-md-6">
              <Form.Item dependencies={['jobID']} label="Lương nhân viên" name="salary" rules={[{ required: true, message: "Vui lòng chọn lương nhân viên" }, { validator: validateSalary }]}>
                <InputNumber placeholder="Nhập  lương nhân viên" style={{ width: '100%' }} min={0} />
              </Form.Item>
            </div>
            <div className="col-md-6">
              <Form.Item label="Công việc" name="jobID" rules={[{ required: true, message: "Vui lòng chọn vị trí nhân viên" }]}>
                <Select className="w-100" key={StaffData} onSelect={handleSelect} ref={selectJob} options={jobData ? jobData.map((element, index) => (
                  { value: element.id, label: element.jobName, salaryMax: element.salaryMax, salaryMin: element.salaryMin }
                )) : {}} />
              </Form.Item>
            </div>
          </div>
          <Form.Item label="Địa chỉ" name="address" rules={[{ required: true, message: "Vui lòng nhập địa chỉ" }]} >
            <TextArea placeholder="Nhập địa chỉ"
              autoSize={{
                minRows: 2,
                maxRows: 4,
              }}></TextArea>
          </Form.Item>
          <Form.Item label="Tiểu sử nhân viên" name="biography" >
            {/* <TextArea placeholder="Nhập tiểu sử nhân viên"
              autoSize={{
                minRows: 4,
                maxRows: 6,
              }}></TextArea> */}
            <Editor data={StaffData.biography ?? ""}
              onChange={(event, editor) => {
                const data = editor.getData();
                form.setFieldsValue({ biography: data }); // Cập nhật vào form
              }}
            />
          </Form.Item>
        </Form>
      </InputModal>

    </div>
  );
}

export default Staff;

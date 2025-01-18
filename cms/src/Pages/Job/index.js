import { ServiceContext } from "../../boot/services";
import { Table, Pagination, Button, Form, InputNumber, Divider, Input, message } from "antd";
import { IoIosAddCircleOutline } from "react-icons/io";
import { useForm } from "antd/es/form/Form";

import { useContext, useEffect, useState, useCallback } from "react";
import { columnNameJob } from "../../CommoHelper/Constant/columnName";
import InputModal from "../../Components/Common/inputModel";
import TextArea from "antd/es/input/TextArea";
import jobService from "../../boot/Service/jobService";


// Chuyển đổi dữ liệu API thành định dạng phù hợp cho bảng
const dataSource = (data) => {
  return data.map((element) => ({
    key: element.id,
    jobName: element.jobName,
    salaryMin: element.salaryMin,
    salaryMax: element.salaryMax,
    description: element.description
  }));
};

// Hàm lấy danh sách công việc và tổng số công việc
const fetchJobsData = async (jobService, filter) => {
  try {
    const [jobsResponse, countResponse] = await Promise.all([
      jobService.getList(filter),
      jobService.getCount()
    ]);


    if (jobsResponse.isSuccess && countResponse.isSuccess) {
      return { jobs: jobsResponse.data, total: countResponse.data };
    }
    return { jobs: [], total: 0 };
  } catch (error) {
    console.error("Lỗi trong fetchJobsData:", error);
    return { jobs: [], total: 0 };
  }
};
const actionJobData = async (jobService, jobData) => {
  try {
    let response;
    if (jobData.id===undefined) {
      response = await jobService.create(jobData)
    }
    else {
      response = await jobService.update(jobData.id, jobData)
    }
    if (response.status === 500) {
      return { success: false, message: response.message };
    }
    return response
  }
  catch (error) {
    console.log("lỗi vào đây");
    return {
      success: false,
      message: "Có lỗi xảy ra trong quá trình xử lý.",
    };
  }
}
const findJob = async (id) => {
  try {
    const response = await jobService.getById(id)
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
function Job() {
  const service = useContext(ServiceContext); // Lấy jobService từ context
  const [data, setData] = useState([]); // Khởi tạo state để lưu dữ liệu
  const [total, setTotal] = useState(1); // Tổng số công việc
  const [filter, setFilter] = useState({
    pageIndex: 1,
    pageSize: 20
  });
  const [title, setTitle] = useState();
  const [open, setOpen] = useState(false);
  const [jobData, setJobData] = useState({})
  const [form] = useForm();
  const validateSalaryRange = (_, value) => {
    const salaryMin = form.getFieldValue('salaryMin');
    const salaryMax = form.getFieldValue('salaryMax');

    if (salaryMin !== undefined && salaryMax !== undefined && salaryMin > salaryMax) {
      return Promise.reject('Mức lương tối thiểu không được lớn hơn mức lương tối đa!');
    }
    return Promise.resolve();
  };

  // Hàm lấy dữ liệu công việc từ API
  const fetchData = useCallback(async () => {

    const { jobs, total } = await fetchJobsData(service.jobService, filter);

    setData(jobs);
    setTotal(total);
  }, [filter, service.jobService]);

  const handleOpenModel = (title) => {
    if (!open) {
      {
        setTitle(title)
        setOpen(true)
      }
    }
  }
  const handleClose = () => {
    if (open ) {
      {
        form.resetFields()
        setOpen(false)
       
        
      }
    }
  }
  // Lắng nghe thay đổi filter (khi thay đổi trang)
  useEffect(() => {
    fetchData();
  }, [fetchData]); // Chạy lại khi filter thay đổi

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

  const onFinish = (values) => {
    console.log(values);
    
    handleClose(); // Đóng modal sau khi submit thành công

  }
  const handleEdit = async (id) => {    
    const response = await findJob(id);
    setJobData(response);
    form.setFieldsValue(response)
    
    handleOpenModel("Chỉnh sửa công việc")
    
  }


  return (
    <div>
      <div className="d-flex justify-content-end mb-3">
        <Button size="large" onClick={(e)=>handleOpenModel('Tạo mới công việc')} icon={<IoIosAddCircleOutline />} type="primary">
          Thêm mới
        </Button>
      </div>
      <Table dataSource={dataSource(data)} scroll={{ x: 'max-content', }} pagination={false} bordered columns={columnNameJob({handleEdit})} />
      <Pagination className="mt-4" align="center" onChange={handlePageChange} current={filter.pageIndex} defaultCurrent={1} pageSize={filter.pageSize} total={total} />
      <InputModal title={title} handleOk={handleSubmit} handleClose={handleClose} isOpen={open}>
        <Divider />
        <Form form={form}  onFinish={onFinish} name="jobForm" layout="vertical">
          <Form.Item name="id" hidden value={jobData.id}>
            <Input disabled />
          </Form.Item>
          <Form.Item label="Tên công việc" name="jobName" rules={[{ required: true, message: "Vui lòng nhập tên công việc" }]}>
            <Input placeholder="Nhập tên công việc" className="w-100"></Input>
          </Form.Item>
          <div className="row">
            <Form.Item className="col-md-6" label="Lương tối thiểu (VNĐ)" name="salaryMin" 

              rules={[
                { required: true, message: 'Vui lòng nhập mức lương tối thiểu!' },
                { validator: validateSalaryRange },
              ]}
            >
              <InputNumber placeholder="Nhập mức lương tối thiểu" className="w-100" min={0} />
            </Form.Item>

            <Form.Item className="col-md-6" label="Lương tối đa (VNĐ)" name="salaryMax" 
              rules={[
                { required: true, message: 'Vui lòng nhập mức lương tối đa!' },
                { validator: validateSalaryRange },
              ]}>
              <InputNumber placeholder="Nhập mức lương tối đa" style={{ width: '100%' }} min={0} />
            </Form.Item>
          </div>
          <Form.Item label="Mô tả công việc" name="description" >
            <TextArea placeholder="Nhập mô tả công việc"
              autoSize={{
                minRows: 4,
                maxRows: 6,
              }}></TextArea>
          </Form.Item>
        </Form>
      </InputModal>
    </div>
  );
}

export default Job;

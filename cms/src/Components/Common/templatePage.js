import services from "../../boot/services";
import { Tooltip, Table, Pagination, Button, Form, InputNumber, Divider, Input, message, Flex, Space } from "antd";
import { IoIosAddCircleOutline } from "react-icons/io";
import { SearchOutlined } from '@ant-design/icons';
import { useContext, useEffect, useState, useCallback } from "react";
import jobColumn from "../../Components/TableColumn/jobColumns";
import InputModal from "../../Components/Common/inputModal";
import TextArea from "antd/es/input/TextArea";
import FormSearch from "../Common/formSearch";
import { getList, actionAsync, deleteAsync, findByID } from "../../CommonHelper/utils/helper/communicateApi";
import { useState, useMemo, useCallback } from "react";


function Table() {

}

function TemplatePage({ children, config }) {
    const [data, setData] = useState([]); // Khởi tạo state để lưu dữ liệu
    const [total, setTotal] = useState(1); // Tổng số công việc
    const [filter, setFilter] = useState({
        pageIndex: 1,
        pageSize: 20,
        orderByColumn: "CreatedDate" || null,
    });
    const [isLoading, setIsLoading] = useState(false);
    const [title, setTitle] = useState();
    const [open, setOpen] = useState(false);
    const [disabled, setDisabled] = useState(false)
    const [form] = config?.form === undefined ? Form.useForm() : config.form;

    const memoizedFilter = useMemo(() => filter, [filter]);
    const fetchData = useCallback(async () => {
        setIsLoading(true);
        try {
            const { data, total } = await getList(config?.service, memoizedFilter);
            setData(data);
            setTotal(total);
        } catch (error) {
            message.error("Lỗi khi tải dữ liệu!");
        } finally {
            setIsLoading(false);
        }
    }, [memoizedFilter, config?.service]);
    useEffect(() => {
        fetchData();
    }, [fetchData]);
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
                setOpen(false)
                if (disabled) {
                    setDisabled(false)
                }

            }
        }
    }
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
    const handeleSearch = (filterValue) => {
        setFilter(pre => {
            return {
                ...pre,
                filters: JSON.stringify(filterValue)
            }
        })
    }
    const onFinish = async (values) => {
        try {
            const response = await actionAsync(config?.service, values);

            if (response.isSuccess) {
                message.success(response.messsage)

                fetchData(); // Làm mới dữ liệu
            } else {
                message.error(response.messsage)
            }
        } catch (error) {
            message.error("Có lỗi xảy ra khi xử lý dữ liệu")

        } finally {
            handleClose();
        }
    }
    const handleEdit = async (id) => {
        const response = await findByID(config?.service, id);
        if (config?.form !== undefined && config?.actiocAssignUrl !== undefined) {
            config.actiocAssignUrl(response)
        }
        form.setFieldsValue(response)
        handleOpenModel(`Chỉnh sửa ${config?.modalName}`)

    }
    const handleDetail = async (id) => {
        const response = await findByID(config?.service, id);
        if (config?.form !== undefined && config?.actiocAssignUrl !== undefined) {
            config.actiocAssignUrl(response)
        }
        setDisabled(true)
        form.setFieldsValue(response)
        handleOpenModel(`Thông tin ${config?.modalName}`)
    }
    const handleDelete = async (id) => {
        try {
            const response = await deleteAsync(config?.service, id);

            if (response.isSuccess) {
                message.success(response.messsage)

                fetchData(); // Làm mới dữ liệu
            } else {
                message.error(response.messsage)

            }
        } catch (error) {
            message.error("Có lỗi xảy ra khi xử lý dữ liệu")

        }
    }

    return (
        <div>
            <div className="d-flex justify-content-between align-items-center mb-3">
                <h4 className="mb-0">{config?.title}</h4>
                <Button size="large" onClick={() => handleOpenModel('Tạo mới công việc')} icon={<IoIosAddCircleOutline />} type="primary">
                    Thêm mới
                </Button>
            </div>
            <FormSearch handleSearch={handeleSearch} filters={config?.filters} />
            <Table loading={isLoading} dataSource={config?.dataSource(data)} rowKey="key" scroll={{ x: 'max-content', }} pagination={false} bordered columns={config?.column({ handleEdit, handleDelete, handleDetail })} />
            <Pagination className="mt-4" align="center" onChange={handlePageChange} current={filter.pageIndex} defaultCurrent={1} pageSize={filter.pageSize} total={total} />
            <InputModal diasbled={disabled} title={title} handleOk={handleSubmit} handleClose={handleClose} width={1000} isOpen={open}>
                <Divider />
                <Form disabled={disabled} form={form} onFinish={onFinish} name="form" layout="vertical">
                    <Form.Item name="id" hidden >
                        <Input disabled />
                    </Form.Item>
                    {children}
                </Form>
            </InputModal>

        </div>
    );
}

export default TemplatePage;

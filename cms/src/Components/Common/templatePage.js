import { Table, Pagination, Button, Form, Divider, Input, message } from "antd";
import { IoIosAddCircleOutline } from "react-icons/io";
import { useMemo, useEffect, useState, useCallback } from "react";
import InputModal from "../../Components/Common/inputModal";
import FormSearch from "../Common/formSearch";
import { getList, actionAsync, deleteAsync, findByID } from "../../CommonHelper/utils/helper/communicateApi";
import useResponseStore from "../../store/responseStore";
import usePageStore from "../../store/pageStore";

// TemplatePage component chính
function TemplatePage({ children, config }) {
    const [data, setData] = useState([]);
    const [total, setTotal] = useState(1);
    const [filter, setFilter] = useState({
        pageIndex: 1,
        pageSize: 20,
        orderByColumn: "CreatedDate",
    });
    const [isLoading, setIsLoading] = useState(false);
    const [title, setTitle] = useState();
    const [open, setOpen] = useState(false);
    const [disabled, setDisabled] = useState(false);
    const [defaultForm] = Form.useForm();
    const { getRequest, getResponse } = useResponseStore();
    const { setDetailData, setFormInstance } = usePageStore()
    const form = config?.form ?? defaultForm;


    // Memoize the filter to avoid unnecessary re-renders
    const memoizedFilter = useMemo(() => filter, [filter]);

    // Fetch data when filter or service changes
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

    const updateFormInstance = useCallback(() => {
        if (config?.form) {
            setFormInstance(config.form);
        }
    }, [config?.form, setFormInstance]); // ✅ Memo hóa function

    useEffect(() => {
        updateFormInstance();
    }, [updateFormInstance]);
    useEffect(() => {
        fetchData();
    }, [fetchData]);

    const handleOpenModal = (title) => {
        setTitle(title);
        setOpen(true);
    };

    const handleClose = () => {
        form.resetFields();
        setDetailData({})
        setOpen(false);
        setDisabled(false);
    };

    const handlePageChange = (page) => {
        setFilter((prevFilter) => ({ ...prevFilter, pageIndex: page }));
    };

    const handleSubmit = async () => {
        try {
            await form.validateFields();
            form.submit();
        } catch (error) {
            console.log('Vui lòng kiểm tra các trường hợp lỗi!');
        }
    };

    const handleSearch = (filterValue) => {
        setFilter((prevFilter) => ({
            ...prevFilter,
            pageIndex: 1,
            filters: JSON.stringify(filterValue),
        }));
    };

    const onFinish = async (values) => {
        try {
            const response = await actionAsync(config?.service, getRequest(values));
            console.log(response);

            if (response.isSuccess) {
                message.success(response.message);
                setFilter({
                    pageIndex: 1,
                    pageSize: 20,
                    orderByColumn: "CreatedDate",
                });
                fetchData(); // Refresh data after submission
            } else {
                message.error(response.message);
            }
        } catch (error) {
            message.error("Có lỗi xảy ra khi xử lý dữ liệu");
        } finally {
            handleClose();
        }
    };

    const handleEdit = async (id) => {
        const response = await findByID(config?.service, id);
        if (config?.form && config?.actiocAssignUrl) {
            config.actiocAssignUrl(response);
        }
        setDetailData(response)
        form.setFieldsValue(getResponse(response));
        handleOpenModal(`Chỉnh sửa ${config?.modalName}`);
    };

    const handleDetail = async (id) => {
        const response = await findByID(config?.service, id);
        if (config?.form && config?.actiocAssignUrl) {
            config.actiocAssignUrl(response);
        }
        setDetailData(response)
        setDisabled(true);
        form.setFieldsValue(getResponse(response));
        handleOpenModal(`Thông tin ${config?.modalName}`);
    };

    const handleDelete = async (id) => {
        try {
            const response = await deleteAsync(config?.service, id);

            if (response.isSuccess) {
                message.success(response.messsage);
                setFilter({
                    pageIndex: 1,
                    pageSize: 20,
                    orderByColumn: "CreatedDate",
                });
                fetchData(); // Refresh data after delete
            } else {
                message.error(response.messsage);
            }
        } catch (error) {
            message.error("Có lỗi xảy ra khi xử lý dữ liệu");
        }
    };

    return (
        <div>
            <div className="d-flex justify-content-between align-items-center mb-3">
                <h4 className="mb-0">{config?.title}</h4>
                <Button size="large" onClick={() => handleOpenModal(`Tạo mới ${config?.modalName}`)} icon={<IoIosAddCircleOutline />} type="primary">
                    Thêm mới
                </Button>
            </div>
            <FormSearch handleSearch={handleSearch} filters={config?.filters} />
            <Table
                loading={isLoading}
                dataSource={config?.dataSource(data, filter?.pageIndex, filter?.pageSize)}
                rowKey="key"
                scroll={{ x: "max-content" }}
                pagination={false}
                bordered
                columns={config?.column({ handleEdit, handleDelete, handleDetail })}
            />
            <Pagination
                className="mt-4"
                align="center"
                onChange={handlePageChange}
                current={filter.pageIndex}
                defaultCurrent={1}
                pageSize={filter.pageSize}
                total={total}
            />
            <InputModal disabled={disabled} title={title} handleOk={handleSubmit} handleClose={handleClose} width={1000} isOpen={open}>
                <Divider />
                <Form disabled={disabled} form={form} onFinish={onFinish} name="form" layout="vertical">
                    <Form.Item name="id" hidden>
                        <Input disabled />
                    </Form.Item>
                    {children}
                </Form>
            </InputModal>
        </div>
    );
}

export default TemplatePage;

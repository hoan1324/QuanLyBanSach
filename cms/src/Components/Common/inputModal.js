import { Modal } from 'antd';
function InputModal({ title, isOpen,handleClose, handleOk, children ,width,diasbled}) {
    return (
        <Modal
            title={title}
            //destroyOnClose={true}
            onClose={handleClose}
            open={isOpen}
            onOk={handleOk}
            onCancel={handleClose}
            okText="Xác nhận"
            cancelText="Hủy"
            centered
            width={width}
            footer={diasbled ? null : undefined} // Sử dụng điều kiện để kiểm soát footer
            >
            {children}
        </Modal>
    )
}
export default InputModal
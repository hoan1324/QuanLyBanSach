import { Modal } from 'antd';
function InputModal({ title, isOpen,handleClose, handleOk, children }) {
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
            width={1000}

        >
            {children}
        </Modal>
    )
}
export default InputModal
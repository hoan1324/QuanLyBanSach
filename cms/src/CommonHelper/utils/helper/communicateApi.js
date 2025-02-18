const handleErrorList = (error, haveTotal = false) => {
    console.error("Lỗi:", error);
    return haveTotal ? { data: [], total: 0 } : [];
};

const findByID = async (service, id) => {
    try {
        const response = await service.getById(id);
        return response?.status === 500 || !response.isSuccess ? null : response.data;
    } catch (error) {
        console.error("Lỗi khi tìm ID:", error);
        return null;
    }
};

const getListDropdown = async (service) => {
    try {
        const response = await service.getListDropdown();
        return response.isSuccess ? response.data : [];
    } catch (error) {
        return handleErrorList(error);
    }
};

const getListDiffirent = async (service, methodName, haveTotal, params) => {
    if (typeof service[methodName] !== "function") return handleErrorList(null, haveTotal);

    try {
        const response = await service[methodName](...params);
        return response.isSuccess
            ? haveTotal 
                ? { data: response.data.data, total: response.data.totalRow } 
                : response.data
            : handleErrorList(null, haveTotal);
    } catch (error) {
        return handleErrorList(error, haveTotal);
    }
};

const getList = async (service, request) => {
    try {
        const response = await service.getList(request);
        return response.isSuccess 
            ? { data: response.data.data, total: response.data.totalRow } 
            : { data: [], total: 0 };
    } catch (error) {
        return handleErrorList(error, true);
    }
};

const actionAsync = async (service, request) => {
    try {
        console.log(request);
        
        const response = request.id === undefined
            ? await service.create(request)
            : await service.update(request.id, request);
        console.log("qUA ĐC K??");
        
        return response?.status === 500 ? { isSuccess: false, message: response.message } : response;
    } catch (error) {  
        console.log("lỗi vào đây");
              
        return { isSuccess: false, message: "Có lỗi xảy ra trong quá trình xử lý." };
    }
};

const deleteAsync = async (service, id) => {
    try {
        const response = await service.delete(id);
        return response?.status === 500 ? { isSuccess: false, message: response.message } : response;
    } catch (error) {
        return { isSuccess: false, message: "Có lỗi xảy ra trong quá trình xử lý." };
    }
};

const actionDiffirent = async (service, methodName, params) => {
    if (typeof service[methodName] !== "function") return { isSuccess: false, message: "Method not found." };

    try {
        const response = await service[methodName](...params);
        return response?.status === 500 ? { isSuccess: false, message: response.message } : response;
    } catch (error) {
        return { isSuccess: false, message: "Có lỗi xảy ra trong quá trình xử lý." };
    }
};

export { findByID, getList, getListDropdown, actionAsync, deleteAsync, actionDiffirent, getListDiffirent };

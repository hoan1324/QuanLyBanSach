import React, { useState } from 'react';
import FileManager from '../../Components/FileManager/fileManager';
import constantType from '../../CommonHelper/Constant/constantType';
import FormSearch from '../../Components/Common/formSearch';
const Home = () => {
  const filter = [
    {
      filterFields: ["JobName", "Description"],
      value: null,
      condition: constantType.filterCondition.contain,
      filterType: constantType.filterType.textBox,
      title: "Tìm kiếm"
    },
    {
      filterFields: ["a", "b"],
      value: null,
      condition: constantType.filterCondition.equal,
      filterType: constantType.filterType.rangeDatePicker,
      title: "Tìm kiếm"
    },
    {
      filterFields: ["c", "d"],
      value: null,
      condition: constantType.filterCondition.equal,
      filterType: constantType.filterType.selectBox,
      options: [{ id: 1, name: "abc" }, { id: 2, name: "haha" }],
      title: "Tìm kiếm"
    },
    {
      filterFields: ["g", "h"],
      value: null,
      condition: constantType.filterCondition.equal,
      filterType: constantType.filterType.dateTimePicker,
      title: "Tìm kiếm"
    }
  ]
  const handelSearch = (value) => {
    console.log(value);

  }
  return (
    <div>
      <FormSearch filters={filter} handleSearch={handelSearch} />
    </div>

  );
};

export default Home;

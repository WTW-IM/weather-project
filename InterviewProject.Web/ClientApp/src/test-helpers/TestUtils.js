import React from 'react';
import Enzyme from "enzyme";
import Adapter from "enzyme-adapter-react-16";
Enzyme.configure({ adapter: new Adapter() });

const TestHook = ({ callback }) => {
  callback();
  return null;
};

export const testHook = (callback) => {
    Enzyme.mount(<TestHook callback={callback} />);
};

//work around for fontAwesome snapshot issue
//https://github.com/FortAwesome/react-fontawesome/issues/194
export const fontAwesomeTitleMock = () => {
  const mockMath = Object.create(global.Math);
  mockMath.random = () => 0.5;
  global.Math = mockMath;
};

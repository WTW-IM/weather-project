import { act } from 'react-dom/test-utils';

//work around for enzyme issue:
//https://github.com/airbnb/enzyme/issues/2073
export const waitForComponentToPaint = async (wrapper) => {
  act(async () => {
    await new Promise(resolve => setTimeout(resolve, 0));
    wrapper.update();
  });
};

//work around for fontAwesome snapshot issue
//https://github.com/FortAwesome/react-fontawesome/issues/194
export const fontAwesomeTitleMock = () => {
  const mockMath = Object.create(global.Math);
  mockMath.random = () => 0.5;
  global.Math = mockMath;
};

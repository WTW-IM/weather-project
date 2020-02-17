import * as React from 'react';
import { Weather } from './Weather';
import { waitForComponentToPaint, fontAwesomeTitleMock } from '../test-helpers/TestUtils';
import Enzyme from "enzyme";
import Adapter from "enzyme-adapter-react-16";
Enzyme.configure({ adapter: new Adapter() });

describe("Weather Component", () => {
    let wrapper;
    
    beforeEach(() => {
        fontAwesomeTitleMock();
        wrapper = Enzyme.mount(
            <Weather/>);
       // waitForComponentToPaint(wrapper);
    });

    it("it should match the snapshot", () => {
        expect(wrapper).toMatchSnapshot();
    });
   

});

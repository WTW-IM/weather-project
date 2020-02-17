import { testHook } from "../../test-helpers/TestUtils";
import { useAxiosLoader } from "./Wrapper";

describe("useAxiosLoader init", () => {
  let loading;
  beforeEach(() => {
    testHook(() => {
      loading = useAxiosLoader();
    });
  });

  it("should return false when no API calls are made", () => {
    expect(loading).toBe(false);
  });
});
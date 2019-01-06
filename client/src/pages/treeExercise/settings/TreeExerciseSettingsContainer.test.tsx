import * as enzyme from "enzyme";
import { shallow } from "enzyme";
import ReactSixteenAdapter from "enzyme-adapter-react-16";
import * as React from "react";

import {
  ITreeExerciseSettingsContainerProps,
  ITreeExerciseSettingsState,
  TreeExerciseSettingsContainer
} from "./TreeExerciseSettingsContainer";
import { SearchRangeType } from "./TreeExerciseSettingsTypes";

enzyme.configure({ adapter: new ReactSixteenAdapter() });

describe("TreeExerciseSettingsContainer tests", () => {
  it("properly renders default values", () => {
    const settingsProps = {
      rangeValue: "3",
      rangeType: SearchRangeType.LessOrEqual
    } as ITreeExerciseSettingsContainerProps;

    const settings = shallow(
      <TreeExerciseSettingsContainer {...settingsProps} />
    );

    const rangeValueInput = settings.find(`Input[data-test-id="range-value"]`);
    const rangeTypeInput = rangeValueInput.find(`Select.range-type__dropdown`);

    expect(rangeValueInput.prop("value")).toBe("3");
    expect(rangeTypeInput.prop("value")).toBe(SearchRangeType.LessOrEqual);
  });

  it("moves control into error state when NaN provided", () => {
    const settingsProps = {
      rangeValue: "3",
      rangeType: SearchRangeType.LessOrEqual,
      rangeValueChanged: jest.fn() as ((rangeValue?: string) => void)
    } as ITreeExerciseSettingsContainerProps;

    const settings = shallow(
      <TreeExerciseSettingsContainer {...settingsProps} />
    );

    const rangeInput = settings.find(`Input[data-test-id="range-value"]`);
    rangeInput.simulate("change", null, { value: "x" });

    expectRangeValueInputIsInErrorState(settings);
  });

  it("moves control into error state when too big range value provided", () => {
    const settingsProps = {
      rangeValue: "3",
      rangeType: SearchRangeType.LessOrEqual,
      rangeValueChanged: jest.fn() as ((rangeValue?: string) => void)
    } as ITreeExerciseSettingsContainerProps;

    const settings = shallow(
      <TreeExerciseSettingsContainer {...settingsProps} />
    );

    const rangeInput = settings.find(`Input[data-test-id="range-value"]`);
    rangeInput.simulate("change", null, { value: "5" });

    expectRangeValueInputIsInErrorState(settings);
  });

  it("moves control into error state when too small range value provided", () => {
    const settingsProps = {
      rangeValue: "3",
      rangeType: SearchRangeType.LessOrEqual,
      rangeValueChanged: jest.fn() as ((rangeValue?: string) => void)
    } as ITreeExerciseSettingsContainerProps;

    const settings = shallow(
      <TreeExerciseSettingsContainer {...settingsProps} />
    );

    const rangeInput = settings.find(`Input[data-test-id="range-value"]`);
    rangeInput.simulate("change", null, { value: "0" });

    expectRangeValueInputIsInErrorState(settings);
  });

  it("calls action when range value changed", () => {
    const rangeValueChangedMock = jest.fn() as ((rangeValue?: string) => void);

    const settingsProps = {
      rangeValue: "3",
      rangeType: SearchRangeType.LessOrEqual,
      rangeValueChanged: rangeValueChangedMock
    } as ITreeExerciseSettingsContainerProps;

    const settings = shallow(
      <TreeExerciseSettingsContainer {...settingsProps} />
    );

    const rangeInput = settings.find(`Input[data-test-id="range-value"]`);
    rangeInput.simulate("change", null, { value: "2" });

    expect(rangeValueChangedMock).toBeCalledWith("2");
    expect(rangeValueChangedMock).toHaveBeenCalledTimes(1);
  });

  it("calls action when range type changed", () => {
    const rangeTypeChangedMock = jest.fn() as ((
      rangeType: SearchRangeType
    ) => void);

    const settingsProps = {
      rangeValue: "3",
      rangeType: SearchRangeType.LessOrEqual,
      rangeTypeChanged: rangeTypeChangedMock
    } as ITreeExerciseSettingsContainerProps;

    const settings = shallow(
      <TreeExerciseSettingsContainer {...settingsProps} />
    );

    const rangeTypeInput = settings.find(
      `Input[data-test-id="range-value"] Select`
    );
    rangeTypeInput.simulate("change", null, { value: SearchRangeType.Equal });

    expect(rangeTypeChangedMock).toBeCalledWith(SearchRangeType.Equal);
    expect(rangeTypeChangedMock).toHaveBeenCalledTimes(1);
  });

  const expectRangeValueInputIsInErrorState = (
    settings: enzyme.ShallowWrapper
  ) => {
    const rangeInput = settings.find(`Input[data-test-id="range-value"]`);
    const settingsState = settings.state() as ITreeExerciseSettingsState;

    expect(rangeInput.prop("error")).toEqual(true);
    expect(settingsState.rangeValueError).toEqual(true);
    expect(settingsState.showErrors).toEqual(true);
  };
});

import * as React from "react";
import { connect } from "react-redux";
import * as Redux from "redux";
import {
  DropdownItemProps,
  DropdownProps,
  Input,
  InputOnChangeData,
  Label,
  Select
} from "semantic-ui-react";

import { IRootState } from "../../../interfaces";
import { SlideBanner } from "../../../shared/components";
import { InfoModal } from "../infoModal";
import {
  changeRangeType,
  changeRangeValue
} from "./TreeExerciseSettingsActions";
import { TreeExerciseSettingsConstants as Constants } from "./TreeExerciseSettingsConstants";
import {
  getTreeExerciseSettingsState,
  isRangeValueValid,
  ITreeExerciseSettingsReduxState
} from "./TreeExerciseSettingsReducer";
import { SearchRangeType } from "./TreeExerciseSettingsTypes";

export interface ITreeExerciseSettingsContainerProps
  extends ITreeExerciseSettingsReduxState,
    ITreeExerciseSettingsDispatch {}

interface ITreeExerciseSettingsDispatch {
  rangeValueChanged: (rangeValue?: string) => void;
  rangeTypeChanged: (rangeType: SearchRangeType) => void;
}

export interface ITreeExerciseSettingsState {
  rangeTypes: DropdownItemProps[];
  rangeValueError: boolean;
  showErrors: boolean;
}

export class TreeExerciseSettingsContainer extends React.PureComponent<
  ITreeExerciseSettingsContainerProps,
  ITreeExerciseSettingsState
> {
  constructor(props: ITreeExerciseSettingsContainerProps, context: {}) {
    super(props, context);

    this.state = this.getInitialState();
  }

  public render(): JSX.Element {
    const { rangeValue, rangeType } = this.props;
    const { rangeTypes, rangeValueError, showErrors } = this.state;

    const showErrorsBanner = !this.isValid() && showErrors;

    return (
      <div className="exercise-settings">
        <SlideBanner
          header="Validation error"
          show={showErrorsBanner}
          onBannerClosed={this.handleValidationBannerClosed}
        >
          <ul>
            {rangeValueError && (
              <li>
                Range value should be a number between {Constants.RangeValueMin}{" "}
                and {Constants.RangeValueMax}.
              </li>
            )}
          </ul>
        </SlideBanner>

        <Input
          type="text"
          placeholder="Positive int."
          value={rangeValue}
          action={true}
          labelPosition="left"
          className="range__group"
          data-test-id="range-value"
          onChange={this.handleRangeValueChanged}
          error={rangeValueError}
        >
          <Label basic={true}>Search range</Label>
          <input className="range__input" />
          <Select
            placeholder="Range type"
            compact={true}
            options={rangeTypes}
            value={rangeType}
            className="range-type__dropdown"
            onChange={this.handleRangeTypeChanged}
          />
        </Input>
        <InfoModal />
      </div>
    );
  }

  private handleRangeValueChanged = (event: {}, data: InputOnChangeData) => {
    const { rangeValueChanged } = this.props;

    this.validateRangeValue(data.value);

    if (!data.value) {
      rangeValueChanged("");
      return;
    }
    rangeValueChanged(data.value);
  };

  private handleRangeTypeChanged = (event: {}, data: DropdownProps) => {
    const { rangeTypeChanged } = this.props;

    rangeTypeChanged(parseInt(data.value as string, 10));
  };

  private handleValidationBannerClosed = () => {
    this.setState({ showErrors: false });
  };

  private validateRangeValue = (value: string): void => {
    if (!value) {
      this.setState({ rangeValueError: false });
      return;
    }

    const { rangeValueError, showErrors } = this.state;

    const isValid = isRangeValueValid(value);
    const newShowErrors =
      (!rangeValueError && !isValid) || (showErrors && !isValid);

    this.setState({ rangeValueError: !isValid, showErrors: newShowErrors });
  };

  private isValid = (): boolean => {
    const { rangeValueError } = this.state;

    return !rangeValueError;
  };

  private getInitialState = (): ITreeExerciseSettingsState => {
    return {
      rangeTypes: [
        {
          text: "Equal",
          value: SearchRangeType.Equal
        },
        {
          text: "Less or equal",
          value: SearchRangeType.LessOrEqual
        }
      ],
      rangeValueError: false,
      showErrors: false
    };
  };
}

const mapStateToProps = (
  state: IRootState,
  ownProps: {}
): ITreeExerciseSettingsReduxState => {
  return getTreeExerciseSettingsState(state);
};

const mapDispatchToProps = (
  dispatch: Redux.Dispatch
): ITreeExerciseSettingsDispatch =>
  Redux.bindActionCreators(
    {
      rangeValueChanged: (rangeValue: string) =>
        changeRangeValue({ range: rangeValue }),
      rangeTypeChanged: (rangeType: SearchRangeType) =>
        changeRangeType({ rangeType })
    },
    dispatch
  );

export const TreeExerciseSettingsView = connect(
  mapStateToProps,
  mapDispatchToProps
)(TreeExerciseSettingsContainer);

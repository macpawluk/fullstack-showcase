import { ITreeExerciseDataReduxState } from "../pages/treeExercise";
import { ITreeExerciseSettingsReduxState } from "../pages/treeExercise/settings";
import { ILoaderReduxState } from "./../shared/smartComponents/loader/LoaderReducer";
import { IRequestErrorPromptReduxState } from "./../shared/smartComponents/requestErrorPrompt/RequestErrorPromptReducer";

export interface IRootState {
  treeExercise: ITreeExerciseReduxState;
  sharedComponents: {
    loader: ILoaderReduxState;
    requestErrorPrompt: IRequestErrorPromptReduxState;
  };
}

interface ITreeExerciseReduxState {
  settings: ITreeExerciseSettingsReduxState;
  data: ITreeExerciseDataReduxState;
}

import { combineReducers } from "redux";
import { treeExerciseDataReducer } from "./pages/treeExercise";
import { treeExerciseSettingsReducer } from "./pages/treeExercise/settings";
import {
  loaderReducer,
  requestErrorPromptReducer
} from "./shared/smartComponents";

export const rootReducer = combineReducers({
  treeExercise: combineReducers({
    settings: treeExerciseSettingsReducer,
    data: treeExerciseDataReducer
  }),
  sharedComponents: combineReducers({
    loader: loaderReducer,
    requestErrorPrompt: requestErrorPromptReducer
  })
});

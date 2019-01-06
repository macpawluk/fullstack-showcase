const lastShowTimeKey = "InfoModalComponent_LastShowTime";

const hour = 1;
const showMinDiff = 24 * hour;

export const shouldShowExerciseInfo = (): boolean => {
  const lastShowTimeString = localStorage.getItem(lastShowTimeKey);

  if (!lastShowTimeString) {
    return true;
  }

  const hoursPassed = getTimeDiffInHoursSinceLastShow();
  return hoursPassed > showMinDiff;
};

export const saveShowExerciseInfoTime = (): void => {
  localStorage.setItem(lastShowTimeKey, Date.now().toString());
};

const getTimeDiffInHoursSinceLastShow = (): number => {
  const lastShowTimeString = localStorage.getItem(lastShowTimeKey);
  const lastShowDateTime = parseInt(lastShowTimeString, 10);

  return (Date.now() - lastShowDateTime) / 36e5;
};

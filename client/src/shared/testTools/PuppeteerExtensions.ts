import puppeteer from "puppeteer";

export const e2eTestTimeout = 16000;

export const getElementText = async (
  page: puppeteer.Page,
  selector: string
): Promise<string> => {
  const textContent = await page.$eval(selector, (e: Element) => e.textContent);

  return textContent as string;
};

export const getElementHtml = async (
  page: puppeteer.Page,
  element: puppeteer.ElementHandle<Element>
): Promise<string> => {
  return await page.evaluate(el => el.innerHTML, element);
};

export const clickElementByTestId = async (
  page: puppeteer.Page,
  testId: string
): Promise<void> => {
  await page.click(`[data-test-id="${testId}"]`);
};

export const clickElementByAttributte = async (
  page: puppeteer.Page,
  attributteName: string,
  attributeValue: string
): Promise<void> => {
  await page.click(`[${attributteName}="${attributeValue}"]`);
};

export const focusElementByTestId = async (
  page: puppeteer.Page,
  testId: string
): Promise<void> => {
  const rangeValueInput = await page.$(`[data-test-id="${testId}"] input`);
  await rangeValueInput.focus();
};

export const delay = async (timeout: number) => {
  return new Promise(resolve => {
    setTimeout(resolve, timeout);
  });
};

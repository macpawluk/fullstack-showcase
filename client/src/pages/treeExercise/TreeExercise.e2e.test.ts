import puppeteer from "puppeteer";
import {
  clickElementByAttributte,
  clickElementByTestId,
  delay,
  focusElementByTestId
} from "../../shared/testTools/PuppeteerExtensions";

describe("Tree Exercise e2e tests", () => {
  test("Page properly loads persons data", async () => {
    const browser = await puppeteer.launch({
      headless: false
    });
    const page = await browser.newPage();

    const requestsData = { capturedRequestUrl: "" };
    interceptApiRequests(page, requestsData);

    await waitForPageWithPersonsToLoad(page);

    expect(requestsData.capturedRequestUrl).toMatch(/get-all/);

    browser.close();
  }, 16000);

  test("Page properly loads contacts data", async () => {
    const browser = await puppeteer.launch({
      headless: false
    });
    const page = await browser.newPage();

    await waitForPageWithPersonsToLoad(page);

    const requestsData = { capturedRequestUrl: "" };
    interceptApiRequests(page, requestsData);

    await clickElementByAttributte(page, "data-test-item", "person-list-item");
    await waitForLoaderToDisappear(page);

    await waitForContactsTreeToLoad(page);

    expect(requestsData.capturedRequestUrl).toMatch(/get-person-contacts/);

    browser.close();
  }, 16000);

  test("Page properly reloads contacts data when range is changed", async () => {
    const browser = await puppeteer.launch({
      headless: false
    });
    const page = await browser.newPage();

    await waitForPageWithPersonsToLoad(page);

    await clickElementByAttributte(page, "data-test-item", "person-list-item");
    await waitForLoaderToDisappear(page);

    await waitForContactsTreeToLoad(page);

    await focusElementByTestId(page, "range-value");

    const requestsData = { capturedRequestUrl: "" };
    interceptApiRequests(page, requestsData);

    await page.keyboard.press("Backspace", { delay: 100 });
    await page.keyboard.type("2", { delay: 100 });

    await waitForLoaderToDisappear(page);
    await waitForContactsTreeToLoad(page);

    expect(requestsData.capturedRequestUrl).toMatch(/searchRangeType=2/);

    browser.close();
  }, 16000);

  test("Page properly validates NaN input", async () => {
    await runValidationTest("x");
  }, 16000);

  test("Page properly validates too big input", async () => {
    await runValidationTest("5");
  }, 16000);

  test("Page properly validates too small input", async () => {
    await runValidationTest("0");
  }, 16000);
});

const runValidationTest = async (rangeValueInput: string) => {
  const browser = await puppeteer.launch({
    headless: false
  });
  const page = await browser.newPage();

  await waitForPageWithPersonsToLoad(page);

  await clickElementByAttributte(page, "data-test-item", "person-list-item");
  await waitForLoaderToDisappear(page);

  await waitForContactsTreeToLoad(page);

  await focusElementByTestId(page, "range-value");

  const requestsData = { capturedRequestUrl: "" };
  interceptApiRequests(page, requestsData);

  await page.keyboard.press("Backspace", { delay: 100 });
  await page.keyboard.type(rangeValueInput, { delay: 100 });

  const errorInput = await page.$(`div[data-test-id="range-value"].error`);

  expect(errorInput).not.toBeNull();
  expect(requestsData.capturedRequestUrl).toBeFalsy();

  browser.close();
};

const interceptApiRequests = (
  page: puppeteer.Page,
  data: { capturedRequestUrl: string }
) => {
  page.on("request", interceptedRequest => {
    const url = interceptedRequest.url();
    if (url.indexOf("api/") >= 0) {
      data.capturedRequestUrl = url;
    }
  });
};

const waitForLoaderToDisappear = async (
  page: puppeteer.Page
): Promise<void> => {
  await page.waitForSelector(".loader__container", { hidden: true });
};

const waitForPageWithPersonsToLoad = async (
  page: puppeteer.Page
): Promise<void> => {
  page.emulate({
    viewport: {
      width: 1600,
      height: 900
    },
    userAgent: ""
  });

  await page.goto("http://localhost:3000/");
  await page.waitForSelector(".home-view-root");

  await updateShowExerciseInfoTime(page);

  await clickElementByTestId(page, "lnk-tree-exercise");
  await page.waitForSelector(".tree-exercise-view-root");
  await delay(1000);

  await waitForLoaderToDisappear(page);
};

const waitForContactsTreeToLoad = async (
  page: puppeteer.Page
): Promise<void> => {
  await page.waitForSelector(".Collapsible__trigger.is-open");
};

const updateShowExerciseInfoTime = async (
  page: puppeteer.Page
): Promise<void> => {
  // This setting will prevent info modal to be shown.
  await page.evaluate(() => {
    localStorage.setItem(
      "InfoModalComponent_LastShowTime",
      Date.now().toString()
    );
  });
};

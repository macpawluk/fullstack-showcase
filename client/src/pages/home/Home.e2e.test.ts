import puppeteer from "puppeteer";
import { getElementText } from "../../shared/testTools/PuppeteerExtensions";

describe("Home View e2e tests", () => {
  test("Summary content loads correctly", async () => {
    const browser = await puppeteer.launch({
      headless: false
    });
    const page = await browser.newPage();

    page.emulate({
      viewport: {
        width: 1600,
        height: 900
      },
      userAgent: ""
    });

    await page.goto("http://localhost:3000/");
    await page.waitForSelector(".home-view-root");

    const summaryText = await getElementText(
      page,
      ".home-view-root .summary-content"
    );

    expect(summaryText).toMatch(/^Currently employed/);

    browser.close();
  }, 16000);
});

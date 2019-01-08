import puppeteer from "puppeteer";
import {
  clickElementByTestId,
  e2eTestTimeout,
  getElementText
} from "../../../shared/testTools/PuppeteerExtensions";

// Here is jest's cache location: C:\Users\Maciek\AppData\Local\Temp\jest

describe("Top Menu e2e tests", () => {
  test(
    "Projects link works",
    async () => {
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
      await page.waitForSelector(".app-menu-root");

      await clickElementByTestId(page, "lnk-projects");
      await page.waitForSelector(".projects-root");

      const firstItemHeaderText = await getElementText(
        page,
        ".project-item h3"
      );

      expect(firstItemHeaderText).toEqual("UBS");

      browser.close();
    },
    e2eTestTimeout
  );

  test(
    "Tree link works",
    async () => {
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
      await page.waitForSelector(".app-menu-root");

      await clickElementByTestId(page, "lnk-tree-exercise");
      await page.waitForSelector(".tree-exercise-view-root");

      const settings = await page.$(".exercise-settings");

      expect(settings).not.toBeNull();

      browser.close();
    },
    e2eTestTimeout
  );

  test(
    "Home link works",
    async () => {
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
      await page.waitForSelector(".app-menu-root");

      await clickElementByTestId(page, "lnk-projects");
      await page.waitForSelector(".projects-root");

      await clickElementByTestId(page, "lnk-home");
      await page.waitForSelector(".home-view-root");

      const summaryContent = await page.$(".summary-content");

      expect(summaryContent).not.toBeNull();

      browser.close();
    },
    e2eTestTimeout
  );
});

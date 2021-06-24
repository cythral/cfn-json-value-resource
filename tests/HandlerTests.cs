using System.Text.Json;
using System.Threading.Tasks;

using FluentAssertions;

using Lambdajection.CustomResource;

using NUnit.Framework;

namespace Cythral.CloudFormation.JsonValue
{
    public class HandlerTests
    {
        [TestFixture]
        public class CreateTests
        {
            [Test, Auto]
            public async Task ShouldReturnAStringJsonValue(
                [Target] Handler handler
            )
            {
                var response = await handler.Create(new CustomResourceRequest<Properties>
                {
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":\"B\"}",
                        Key = "A",
                    },
                });

                response.Result!.ToString().Should().Be("B");
            }

            [Test, Auto]
            public async Task ShouldReturnANumberJsonValue(
                [Target] Handler handler
            )
            {
                var response = await handler.Create(new CustomResourceRequest<Properties>
                {
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":1}",
                        Key = "A",
                    },
                });

                response.Result.As<JsonElement>().GetInt32().Should().Be(1);
            }

            [Test, Auto]
            public async Task ShouldReturnARandomStringForPhysicalResourceId(
                [Target] Handler handler
            )
            {
                var response = await handler.Create(new CustomResourceRequest<Properties>
                {
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":1}",
                        Key = "A",
                    },
                });

                response.Id.Should().NotBeEmpty();
            }
        }

        [TestFixture]
        public class UpdateTests
        {
            [Test, Auto]
            public async Task ShouldReturnAStringJsonValue(
                string physicalResourceId,
                [Target] Handler handler
            )
            {
                var response = await handler.Update(new CustomResourceRequest<Properties>
                {
                    PhysicalResourceId = physicalResourceId,
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":\"B\"}",
                        Key = "A",
                    },
                });

                response.Result!.ToString().Should().Be("B");
            }

            [Test, Auto]
            public async Task ShouldReturnANumberJsonValue(
                string physicalResourceId,
                [Target] Handler handler
            )
            {
                var response = await handler.Update(new CustomResourceRequest<Properties>
                {
                    PhysicalResourceId = physicalResourceId,
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":1}",
                        Key = "A",
                    },
                });

                response.Result.As<JsonElement>().GetInt32().Should().Be(1);
            }

            [Test, Auto]
            public async Task ShouldReturnTheGivenPhysicalResourceId(
                string physicalResourceId,
                [Target] Handler handler
            )
            {
                var response = await handler.Update(new CustomResourceRequest<Properties>
                {
                    PhysicalResourceId = physicalResourceId,
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":1}",
                        Key = "A",
                    },
                });

                response.Id.Should().Be(physicalResourceId);
            }
        }

        [TestFixture]
        public class DeleteTests
        {
            [Test, Auto]
            public async Task ShouldReturnAStringJsonValue(
                [Target] Handler handler
            )
            {
                var response = await handler.Delete(new CustomResourceRequest<Properties>
                {
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":\"B\"}",
                        Key = "A",
                    },
                });

                response.Result!.ToString().Should().Be("B");
            }

            [Test, Auto]
            public async Task ShouldReturnANumberJsonValue(
                [Target] Handler handler
            )
            {
                var response = await handler.Delete(new CustomResourceRequest<Properties>
                {
                    ResourceProperties = new Properties
                    {
                        Json = "{\"A\":1}",
                        Key = "A",
                    },
                });

                response.Result.As<JsonElement>().GetInt32().Should().Be(1);
            }
        }
    }
}
